using MongoDB.Driver;
using MongoDB.Driver.GeoJsonObjectModel;
using SmartCity.Application.Abstractions.Repositories.GisOsm;
using SmartCity.Domain.Entities.GisOsm;
using SmartCity.Infrastructure.DataContext;

namespace SmartCity.Infrastructure.Repositories.GisOsm;

public class OsmPoiRepository(GisOsmContext context) : IOsmPoiRepository {
    private readonly GisOsmContext _context = context;

    public async Task<List<OsmPoi>> GetNearSphereAsync(double lat, double lon, string type, double distance) {
        var point = GeoJson.Point(GeoJson.Position(lon, lat));
        var nearSphereFilter = Builders<OsmPoi>.Filter.NearSphere(x => x.Geometry, point, distance);
        var typeFilter = Builders<OsmPoi>.Filter.Eq(x => x.Properties.Fclass, type);
        var filter = !string.IsNullOrEmpty(type)
            ? Builders<OsmPoi>.Filter.And(nearSphereFilter, typeFilter)
            : nearSphereFilter;
        return await _context.Poi.Find(filter).ToListAsync();
    }
}