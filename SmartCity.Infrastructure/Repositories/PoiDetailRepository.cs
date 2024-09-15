using Microsoft.EntityFrameworkCore;
using SmartCity.Application.Abstractions.Repositories;
using SmartCity.Domain.Entities;
using SmartCity.Infrastructure.DataContext;

namespace SmartCity.Infrastructure.Repositories;
public class PoiDetailsRepository(SmartCityContext context) : IPoiDetailRepository {
    private readonly SmartCityContext _context = context;

    public async Task<List<PoiDetail>> GetPoiDetailsByGidsAsync(List<int> poiGids) {
        return await _context.PoiDetails
             .Include(d => d.PoiPhotos)
             .Include(d => d.PoiReviews)
             .Where(p => poiGids.Contains(p.PoiGid) && !p.DeleteFlag)
             .ToListAsync();
    }

    public async Task<PoiDetail?> GetPoiDetailsByGidAsync(int poiGid) {
        return await _context.PoiDetails
            .Include(d => d.PoiPhotos)
            .Include(d => d.PoiReviews)
            .FirstOrDefaultAsync(p => p.PoiGid == poiGid && !p.DeleteFlag);
    }

    public async Task UpdatePoiDetailsAsync(PoiDetail poiDetails) {
        _context.PoiDetails.Update(poiDetails);
        await _context.SaveChangesAsync();
    }

    public async Task DeletePoiDetailsAsync(int poiGid) {
        var poiDetails = await _context.PoiDetails.FirstOrDefaultAsync(p => p.PoiGid == poiGid);
        if (poiDetails != null) {
            poiDetails.DeleteFlag = true;
            await _context.SaveChangesAsync();
        }
    }
}

