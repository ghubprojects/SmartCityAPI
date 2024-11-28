using Microsoft.EntityFrameworkCore;
using SmartCity.Application.Abstractions.Repositories;
using SmartCity.Infrastructure.DataContext;

namespace SmartCity.Infrastructure.Repositories;

public class PlaceTypeRepository(AppDbContext context) : IPlaceTypeRepository {
    private readonly AppDbContext _context = context;

    public async Task<string?> GetFClassAsync(string type) {
        var item = await _context.MPlaceTypes
            .Where(p => p.TypeName.Replace(" ", "").ToLower() == type.Replace(" ", "").ToLower())
            .FirstOrDefaultAsync();
        return item?.Fclass;
    }

    public async Task<Dictionary<string, string>> GetTypeDictAsync() {
        return await _context.MPlaceTypes
             .ToDictionaryAsync(x => x.Fclass, x => x.TypeName);
    }
}
