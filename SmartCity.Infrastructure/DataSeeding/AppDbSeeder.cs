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

    public async Task SeedAsync() {
        _context.Database.EnsureCreated();

        await SeedUserAsync();
        await SeedPlaceTypeAsync();
        await SeedPlaceAsync();

        _context.ChangeTracker.Clear();
    }

    private async Task SeedUserAsync() {
        if (await _context.MUsers.AnyAsync())
            return;

        var users = Enumerable.Range(1, 20).Select(i => new MUser {
            Username = $"user{i:D2}",
            Email = $"user{i:D2}@gmail.com",
            PasswordHash = $"pass{i:D6}",
        }).ToList();

        await _context.MUsers.AddRangeAsync(users);
        await _context.SaveChangesAsync();
    }

    private async Task SeedPlaceTypeAsync() {
        if (await _context.MPlaceTypes.AnyAsync())
            return;

        var distinctFclasses = await _gisOsmContext.Poi
            .Distinct<string>("Properties.Fclass", Builders<Poi>.Filter.Empty)
            .ToListAsync();

        var placeTypes = distinctFclasses.Select(fclass => new MPlaceType {
            TypeName = SeedUtil.GetPlaceType(fclass),
            Fclass = fclass
        }).ToList();

        await _context.MPlaceTypes.AddRangeAsync(placeTypes);
        await _context.SaveChangesAsync();
    }

    private async Task SeedPlaceAsync() {
        if (await _context.MPlaceDetails.AnyAsync())
            return;

        // Cache users and existing files
        var users = await _context.MUsers.AsNoTracking().ToListAsync();
        var existingFileNames = (await _context.MFiles
            .Select(file => file.FileName)
            .ToListAsync())
            .ToHashSet();

        var placeDetails = new List<MPlaceDetail>();
        var files = new List<MFile>();
        var placePhotos = new List<TPlacePhoto>();
        var placeReviews = new List<TPlaceReview>();

        var pois = _gisOsmContext.Poi.AsQueryable()
            .AsNoTracking()
            .ToList();


        // Collect MPlaceDetail records first
        foreach (var poi in pois) {
            var placeDetail = new MPlaceDetail {
                OsmId = poi.Properties.OsmId,
                Description = SeedUtil.GetDescription(poi.Properties.Fclass, poi.Properties.Name),
                OpeningHours = SeedUtil.GetOpeningHours(poi.Properties.Fclass),
            };
            placeDetails.Add(placeDetail);
        }

        // Save MPlaceDetails to ensure they have generated IDs
        await _context.MPlaceDetails.AddRangeAsync(placeDetails);
        await _context.SaveChangesAsync();

        var savedPlaceTypes = pois.ToDictionary(p => p.Properties.OsmId, p => p.Properties.Fclass);

        // Add MFile records and seed photos and reviews in batches
        foreach (var placeDetail in placeDetails) {
            var placeType = savedPlaceTypes[placeDetail.OsmId];
            var imageUrls = SeedUtil.GetImageUrls(placeType);

            var newFiles = imageUrls
                .Where(url => !existingFileNames.Contains(new Uri(url).Segments[^1]))
                .Select(url => new MFile {
                    FileName = new Uri(url).Segments[^1],
                    FilePath = url,
                }).ToList();

            files.AddRange(newFiles);
            existingFileNames.UnionWith(newFiles.Select(f => f.FileName));

            placePhotos.AddRange(imageUrls
                .Where(url => existingFileNames.Contains(new Uri(url).Segments[^1]))
                .Select(url => new TPlacePhoto {
                    DetailId = placeDetail.DetailId,
                    FileId = files.First(f => f.FileName == new Uri(url).Segments[^1]).FileId,
                }));

            var reviewEntities = SeedUtil.GetComments(placeType).Select(comment => new TPlaceReview {
                DetailId = placeDetail.DetailId,
                UserId = users[_random.Next(users.Count)].UserId,
                Comment = comment,
                Rating = _random.Next(1, 6),
            }).ToList();

            placeReviews.AddRange(reviewEntities);
        }

        // Add and save all remaining entities in batch
        await _context.MFiles.AddRangeAsync(files);
        await _context.SaveChangesAsync();

        await _context.TPlacePhotos.AddRangeAsync(placePhotos);
        await _context.TPlaceReviews.AddRangeAsync(placeReviews);
        await _context.SaveChangesAsync();

        await _context.TPlacePhotos.AddRangeAsync(placePhotos);
        await _context.TPlaceReviews.AddRangeAsync(placeReviews);
        await _context.SaveChangesAsync();
    }

}
