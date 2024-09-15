using Microsoft.EntityFrameworkCore;
using SmartCity.Application.Abstractions.Repositories;
using SmartCity.Domain.Entities;
using SmartCity.Infrastructure.DataContext;

namespace SmartCity.Infrastructure.Repositories;

public class PoiPhotoRepository(SmartCityContext context) : IPoiPhotoRepository {
    private readonly SmartCityContext _context = context;

    public async Task<List<PoiPhoto>> GetPhotosByPoiGidAsync(int poiGid) {
        return await _context.PoiPhotos
            .Where(x => x.DetailId.Equals(poiGid) && !x.DeleteFlag)
            .ToListAsync();
    }

    public async Task AddPhotoAsync(PoiPhoto photo) {
        _context.PoiPhotos.Add(photo);
        await _context.SaveChangesAsync();
    }

    public async Task UpdatePhotoAsync(PoiPhoto photo) {
        _context.PoiPhotos.Update(photo);
        await _context.SaveChangesAsync();
    }

    public async Task DeletePhotoAsync(int photoId) {
        var photo = await _context.PoiPhotos.FindAsync(photoId);
        if (photo != null) {
            photo.DeleteFlag = true;
            await _context.SaveChangesAsync();
        }
    }
}
