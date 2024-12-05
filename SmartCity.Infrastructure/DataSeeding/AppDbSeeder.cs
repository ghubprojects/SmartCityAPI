using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using SmartCity.Domain.Entities;
using SmartCity.Domain.Entities.GisOsm;
using SmartCity.Infrastructure.DataContext;
using SmartCity.Infrastructure.Utils;

namespace SmartCity.Infrastructure.DataSeeding;

public class AppDbSeeder(AppDbContext context, GisOsmContext gisOsmContext) {
    private readonly AppDbContext _context = context;
    private readonly GisOsmContext _gisOsmContext = gisOsmContext;
    private readonly Random _random = new();

    public async Task InitialiseAsync() {
        if (_context.Database.IsRelational())
            await _context.Database.MigrateAsync();
    }

    public async Task SeedAsync() {
        _context.Database.EnsureCreated();

        await SeedAdministrativeAreaAsync();
        await SeedFileAsync();
        await SeedUserAsync();
        await SeedPlaceTypeAsync();
        await SeedPlaceAsync();
        await SeedPhotoAndReviewAsync();

        _context.ChangeTracker.Clear();
    }

    private async Task SeedAdministrativeAreaAsync() {
        if (await _context.MAdministrativeAreas.AnyAsync())
            return;

        var gadmLv1 = await _gisOsmContext.GadmLv1.Find(_ => true).ToListAsync();
        var areaLv1 = gadmLv1.Select(area => new MAdministrativeArea {
            AreaName = area.Properties.Name1,
            AreaType = area.Properties.Type1,
            EngType = area.Properties.EngType1,
            ParentId = null
        }).ToList();

        await _context.MAdministrativeAreas.AddRangeAsync(areaLv1);
        await _context.SaveChangesAsync();

        var gadmLv2 = await _gisOsmContext.GadmLv2.Find(_ => true).ToListAsync();
        var areaLv2 = gadmLv2.Select(area => new MAdministrativeArea {
            AreaName = area.Properties.Name2,
            AreaType = area.Properties.Type2,
            EngType = area.Properties.EngType2,
            ParentId = areaLv1.FirstOrDefault(a => a.AreaName == area.Properties.Name1)?.AreaId
        }).ToList();

        await _context.MAdministrativeAreas.AddRangeAsync(areaLv2);
        await _context.SaveChangesAsync();
    }

    private async Task SeedFileAsync() {
        if (await _context.MFiles.AnyAsync())
            return;

        var avatarFiles = SeedUtil.GetAvatarUrls().Select(url => new MFile {
            FilePath = url,
            FileName = new Uri(url).Segments[^1],
        });
        var placePhotos = SeedUtil.GetImageUrls().Select(url => new MFile {
            FilePath = url,
            FileName = new Uri(url).Segments[^1],
        });

        await _context.MFiles.AddRangeAsync(avatarFiles);
        await _context.MFiles.AddRangeAsync(placePhotos);
        await _context.SaveChangesAsync();
    }

    private async Task SeedUserAsync() {
        if (await _context.MUsers.AnyAsync())
            return;

        var files = await _context.MFiles.AsNoTracking().ToListAsync();
        var users = Enumerable.Range(1, 20).Select(i => new MUser {
            Username = $"user{i:D2}",
            Email = $"user{i:D2}@gmail.com",
            PasswordHash = $"pass{i:D6}",
            AvatarId = i
        }).ToList();

        await _context.MUsers.AddRangeAsync(users);
        await _context.SaveChangesAsync();
    }

    private async Task SeedPlaceTypeAsync() {
        if (await _context.MPlaceTypes.AnyAsync())
            return;

        var fClassList = await _gisOsmContext.Poi.Aggregate()
            .Group(p => p.Properties.Fclass, g => new { Fclass = g.Key, Count = g.Count() })
            .SortByDescending(g => g.Count)
            .Project(g => g.Fclass)
            .ToListAsync();

        var placeTypes = fClassList.Select(fclass => new MPlaceType {
            Fclass = fclass,
            TypeName = SeedUtil.GetPlaceType(fclass)
        }).ToList();

        await _context.MPlaceTypes.AddRangeAsync(placeTypes);
        await _context.SaveChangesAsync();
    }

    private async Task SeedPlaceAsync() {
        if (await _context.MPlaceDetails.AnyAsync())
            return;

        var placeDetails = new List<MPlaceDetail>();
        var pois = _gisOsmContext.Poi.AsQueryable().AsNoTracking().ToList();

        foreach (var poi in pois) {
            var placeDetail = new MPlaceDetail {
                OsmId = poi.Properties.OsmId,
                Description = SeedUtil.GetDescription(poi.Properties.Fclass, poi.Properties.Name),
                OpeningHours = SeedUtil.GetOpeningHours(poi.Properties.Fclass),
            };
            placeDetails.Add(placeDetail);
        }

        await _context.MPlaceDetails.AddRangeAsync(placeDetails);
        await _context.SaveChangesAsync();
    }

    private async Task SeedPhotoAndReviewAsync() {
        if (await _context.TPlacePhotos.AnyAsync() || await _context.TPlaceReviews.AnyAsync())
            return;

        var files = await _context.MFiles.AsNoTracking().ToListAsync();
        var placePhotos = new List<TPlacePhoto>();
        var placeReviews = new List<TPlaceReview>();

        var pois = _gisOsmContext.Poi.AsQueryable().AsNoTracking().ToList();
        var placeTypeDict = pois.DistinctBy(p => p.Properties.OsmId)
                                .ToDictionary(p => p.Properties.OsmId, p => p.Properties.Fclass);
        var placeDetails = await _context.MPlaceDetails.AsNoTracking().ToListAsync();
        var users = await _context.MUsers.AsNoTracking().ToListAsync();

        foreach (var placeDetail in placeDetails) {
            var placeType = placeTypeDict[placeDetail.OsmId];
            var imageUrls = SeedUtil.GetImageUrls(placeType);

            placePhotos.AddRange(imageUrls
                .Select(url => {
                    var savedFile = files.First(f => f.FilePath == url);
                    return new TPlacePhoto {
                        DetailId = placeDetail.DetailId,
                        FileId = savedFile.FileId,
                    };
                }));

            var reviewEntities = SeedUtil.GetComments(placeType).Select(comment => new TPlaceReview {
                DetailId = placeDetail.DetailId,
                UserId = users[_random.Next(users.Count)].UserId,
                Comment = comment,
                Rating = _random.Next(1, 6),
            }).ToList();

            placeReviews.AddRange(reviewEntities);
        }

        await _context.TPlacePhotos.AddRangeAsync(placePhotos);
        await _context.TPlaceReviews.AddRangeAsync(placeReviews);
        await _context.SaveChangesAsync();
    }
}
