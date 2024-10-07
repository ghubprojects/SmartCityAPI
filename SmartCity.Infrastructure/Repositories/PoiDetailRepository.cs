using Microsoft.EntityFrameworkCore;
using SmartCity.Application.Abstractions.Repositories;
using SmartCity.Domain.Entities;
using SmartCity.Infrastructure.DataContext;

namespace SmartCity.Infrastructure.Repositories;

public class PoiDetailsRepository(AppDbContext context) : IPoiDetailRepository {
    private readonly AppDbContext _context = context;

    public async Task<List<PoiDetail>> GetDataListAsync(List<string> osmIds) {
        return await _context.PoiDetails
             .Include(d => d.PoiPhotos)
             .Include(d => d.PoiReviews)
             .AsSplitQuery()
             .Where(p => osmIds.Contains(p.OsmId) && !p.DeleteFlag)
             .ToListAsync();
    }

    public async Task<PoiDetail?> GetDataAsync(string osmId) {
        return await _context.PoiDetails
            .Include(d => d.PoiPhotos)
            .Include(d => d.PoiReviews)
            .AsSplitQuery()
            .FirstOrDefaultAsync(p => p.OsmId == osmId && !p.DeleteFlag);
    }
}

