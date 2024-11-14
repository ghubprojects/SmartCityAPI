using MongoDB.Driver;
using MongoDB.Driver.GeoJsonObjectModel;
using SmartCity.Application.Abstractions.Repositories.GisOsm;
using SmartCity.Domain.Entities.GisOsm;
using SmartCity.Infrastructure.DataContext;

namespace SmartCity.Infrastructure.Repositories.GisOsm;

public class PoiRepository(GisOsmContext context) : IPoiRepository {
    private readonly GisOsmContext _context = context;

    public async Task<List<Poi>> GetNearSphereAsync(double lat, double lon, string type, double distance) {
        var point = GeoJson.Point(GeoJson.Position(lon, lat));
        var nearSphereFilter = Builders<Poi>.Filter.NearSphere(x => x.Geometry, point, distance);
        var typeFilter = Builders<Poi>.Filter.Eq(x => x.Properties.Fclass, type);
        var filter = !string.IsNullOrEmpty(type)
            ? Builders<Poi>.Filter.And(nearSphereFilter, typeFilter)
            : nearSphereFilter;
        return await _context.Poi.Find(filter).ToListAsync();
    }
}