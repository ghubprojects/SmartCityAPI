using MongoDB.Driver;
using MongoDB.Driver.GeoJsonObjectModel;
using SmartCity.Application.Abstractions.Repositories.GisOsm;
using SmartCity.Domain.Entities.GisOsm;
using SmartCity.Infrastructure.DataContext;

namespace SmartCity.Infrastructure.Repositories.GisOsm;

public class PoiRepository(GisOsmContext context) : IPoiRepository {
    private readonly GisOsmContext _context = context;

    public async Task<List<Poi>> GetNearSphereAsync(double lat, double lon, string type, double distance) {
        var builder = Builders<Poi>.Filter;
        var location = GeoJson.Point(GeoJson.Position(lon, lat));
        var nearSphereFilter = builder.NearSphere(x => x.Geometry, location, distance);
        FilterDefinition<Poi> filter = nearSphereFilter;

        if (!string.IsNullOrEmpty(type)) {
            var typeFilter = builder.Eq(x => x.Properties.Fclass, type);
            filter = builder.And(nearSphereFilter, typeFilter);
        }
        return await _context.Poi.Find(filter).ToListAsync();
    }

    public async Task<List<Poi>> GetWithinAreaAsync(GeoJsonGeometry<GeoJson2DCoordinates> areaGeometry) {
        var filter = Builders<Poi>.Filter.GeoWithin(x => x.Geometry, areaGeometry);
        return await _context.Poi.Find(filter).ToListAsync();
    }
}