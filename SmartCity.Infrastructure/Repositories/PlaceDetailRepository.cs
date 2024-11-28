using Microsoft.EntityFrameworkCore;
using SmartCity.Application.Abstractions.Repositories;
using SmartCity.Domain.Entities;
using SmartCity.Infrastructure.DataContext;

namespace SmartCity.Infrastructure.Repositories;

public class PlaceDetailRepository(AppDbContext context) : IPlaceDetailRepository {
    private readonly AppDbContext _context = context;

    private IQueryable<MPlaceDetail> GetQueryAsync() {
        return _context.MPlaceDetails
             .Include(d => d.TPlacePhotos)
             .ThenInclude(p => p.File)
             .Include(d => d.TPlaceReviews)
             .ThenInclude(r => r.User)
             .ThenInclude(u => u.Avatar)
             .AsSplitQuery();
    }

    public async Task<List<MPlaceDetail>> GetDataListAsync(List<string> osmIds) {
        return await GetQueryAsync()
             .Where(p => osmIds.Contains(p.OsmId))
             .ToListAsync();
    }

    public async Task<MPlaceDetail?> GetDataAsync(string osmId) {
        return await GetQueryAsync().FirstOrDefaultAsync(p => p.OsmId == osmId);
    }
}

