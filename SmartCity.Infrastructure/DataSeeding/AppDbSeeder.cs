//using MongoDB.Driver;
//using SmartCity.Domain.Entities;
//using SmartCity.Domain.Entities.GisOsm;
//using SmartCity.Infrastructure.DataContext;
//using SmartCity.Infrastructure.Utils;

//namespace SmartCity.Infrastructure.DataSeeding;

//public class AppDbSeeder(AppDbContext context, GisOsmContext gisOsmContext) {
//    private readonly AppDbContext _context = context;
//    private readonly GisOsmContext _gisOsmContext = gisOsmContext;

//    public async Task SeedAsync() {
//        _context.Database.EnsureCreated();
//        await SeedUserAsync();
//        await SeedPlaceTypeAsync();
//        await SeedPlaceAsync();
//        _context.ChangeTracker.Clear();
//    }

//    private async Task SeedUserAsync() {
//        if (_context.MUsers.Any()) {
//            return;
//        }

//        var users = Enumerable.Range(1, 20).ToList().Select(i => new MUser {
//            Username = $"user{i:D2}",
//            Email = $"user{i:D2}@gmail.com",
//            PasswordHash = $"pass{i:D6}",
//        });
//        await _context.MUsers.AddRangeAsync(users);
//        await _context.SaveChangesAsync();
//    }

//    private async Task SeedPlaceTypeAsync() {
//        if (_context.MPlaceTypes.Any()) {
//            return;
//        }

//        var distinctFclasses = await _gisOsmContext.Poi
//            .Distinct<string>("Properties.Fclass", Builders<Poi>.Filter.Empty)
//            .ToListAsync();
//        var placeTypes = distinctFclasses
//            .Select(fclass => new MPlaceType {
//                TypeName = SeedUtil.GetPlaceType(fclass),
//                Fclass = fclass
//            });
//        await _context.MPlaceTypes.AddRangeAsync(placeTypes);
//        await _context.SaveChangesAsync();
//    }

//    private async Task SeedPlaceAsync() {
//        if (_context.MPlaceDetails.Any()) {
//            return;
//        }

//        foreach (var poi in _gisOsmContext.Poi.AsQueryable()) {
//            var placeType = poi.Properties.Fclass;

//            // Seed place detail
//            var placeDetail = new MPlaceDetail {
//                OsmId = poi.Properties.OsmId,
//                Description = SeedUtil.GetDescription(placeType, poi.Properties.Name),
//                OpeningHours = SeedUtil.GetOpeningHours(placeType),
//            };
//            await _context.MPlaceDetails.AddAsync(placeDetail);

//            // Seed files
//            var files = SeedUtil.GetImageUrls(placeType)
//                .Select(url => new MFile {
//                    FileName = new Uri(url).Segments[^1],
//                    FilePath = url,
//                });
//            if (!_context.MFiles.Where(file => file.FileName == files.First().FileName).Any()) {
//                await _context.MFiles.AddRangeAsync(files);
//            }

//            // Seed place photos
//            var placePhotos = files
//                .Select(file => new TPlacePhoto {
//                    DetailId = placeDetail.DetailId,
//                    FileId = file.FileId,
//                });
//            placeDetail.TPlacePhotos = placePhotos.ToList();
//            await _context.TPlacePhotos.AddRangeAsync(placePhotos);

//            // Seed place reviews
//            var placeReviews = SeedUtil.GetComments(placeType)
//                .Select(comment => new TPlaceReview {
//                    DetailId = placeDetail.DetailId,
//                    UserId = _context.MUsers.ElementAt(new Random().Next(1, 21)).UserId,
//                    Comment = comment,
//                    Rating = new Random().Next(1, 6),
//                });
//            placeDetail.TPlaceReviews = placeReviews.ToList();
//            await _context.TPlaceReviews.AddRangeAsync(placeReviews);

//            await _context.SaveChangesAsync();
//        }
//        // Save changes
//        await _context.SaveChangesAsync();
//    }
//}

using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using SmartCity.Domain.Entities;
using SmartCity.Domain.Entities.GisOsm;
using SmartCity.Infrastructure.DataContext;
using SmartCity.Infrastructure.Utils;

namespace SmartCity.Infrastructure.DataSeeding;

public class AppDbSeeder {
    private readonly AppDbContext _context;
    private readonly GisOsmContext _gisOsmContext;
    private readonly Random _random = new();

    public AppDbSeeder(AppDbContext context, GisOsmContext gisOsmContext) {
        _context = context;
        _gisOsmContext = gisOsmContext;
    }

    public async Task SeedAsync() {
        _context.Database.EnsureCreated();

        await SeedUserAsync();
        await SeedPlaceTypeAsync();
        await SeedPlaceAsync();

        _context.ChangeTracker.Clear();
    }

    private async Task SeedUserAsync() {
        if (_context.MUsers.Any())
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
        if (_context.MPlaceTypes.Any())
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
        if (_context.MPlaceDetails.Any())
            return;

        // Cache all MUsers and existing MFiles to avoid repeated database queries in the loop
        var users = await _context.MUsers.ToListAsync();
        var existingFileNames = _context.MFiles
            .Select(file => file.FileName)
            .ToHashSet();

        var placeDetails = new List<MPlaceDetail>();
        var files = new List<MFile>();
        var placePhotos = new List<TPlacePhoto>();
        var placeReviews = new List<TPlaceReview>();

        // Collect MPlaceDetail records first
        foreach (var poi in _gisOsmContext.Poi.AsQueryable().AsNoTracking()) {
            var placeType = poi.Properties.Fclass;

            var placeDetail = new MPlaceDetail {
                OsmId = poi.Properties.OsmId,
                Description = SeedUtil.GetDescription(placeType, poi.Properties.Name),
                OpeningHours = SeedUtil.GetOpeningHours(placeType),
            };
            placeDetails.Add(placeDetail);
        }

        // Save MPlaceDetails to ensure they have generated IDs
        await _context.MPlaceDetails.AddRangeAsync(placeDetails);
        await _context.SaveChangesAsync();

        // Create and save MFile records first to obtain their FileId
        foreach (var placeDetail in placeDetails) {
            var placeType = placeDetail.OsmId; // Use the OsmId as the type or any other way to get type

            // Seed files (only add new files)
            var imageUrls = SeedUtil.GetImageUrls(placeType);
            var newFiles = imageUrls
                .Where(url => !existingFileNames.Contains(new Uri(url).Segments[^1])) // Skip existing files
                .Select(url => new MFile {
                    FileName = new Uri(url).Segments[^1],
                    FilePath = url,
                }).ToList();

            files.AddRange(newFiles);
            existingFileNames.UnionWith(newFiles.Select(f => f.FileName));
        }

        // Save MFile records to generate FileId values
        await _context.MFiles.AddRangeAsync(files);
        await _context.SaveChangesAsync();

        // Build a dictionary of saved MFiles for fast lookup by FileName
        var savedFiles = _context.MFiles.ToDictionary(f => f.FileName, f => f.FileId);

        // Create TPlacePhoto and TPlaceReview records
        foreach (var placeDetail in placeDetails) {
            var placeType = placeDetail.OsmId; // Use the OsmId as the type or any other way to get type
            var imageUrls = SeedUtil.GetImageUrls(placeType);

            // Seed place photos with valid DetailId and FileId
            placePhotos.AddRange(imageUrls
                .Where(url => savedFiles.ContainsKey(new Uri(url).Segments[^1]))
                .Select(url => new TPlacePhoto {
                    DetailId = placeDetail.DetailId,
                    FileId = savedFiles[new Uri(url).Segments[^1]], // Use saved FileId
                }));

            // Seed place reviews
            var reviewEntities = SeedUtil.GetComments(placeType).Select(comment => new TPlaceReview {
                DetailId = placeDetail.DetailId,
                UserId = users[_random.Next(users.Count)].UserId,
                Comment = comment,
                Rating = _random.Next(1, 6),
            }).ToList();

            placeReviews.AddRange(reviewEntities);
        }

        // Add and save all remaining entities in batch
        await _context.TPlacePhotos.AddRangeAsync(placePhotos);
        await _context.TPlaceReviews.AddRangeAsync(placeReviews);
        await _context.SaveChangesAsync();
    }

}
