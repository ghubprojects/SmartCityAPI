using MongoDB.Driver;
using MongoDB.Driver.GeoJsonObjectModel;
using SmartCity.Application.Abstractions.Repositories.GisOsm;
using SmartCity.Domain.Entities.GisOsm;
using SmartCity.Infrastructure.DataContext;

namespace SmartCity.Infrastructure.Repositories.GisOsm;

public class PoiRepository(GisOsmContext context) : IPoiRepository {
    private readonly GisOsmContext _context = context;

    public async Task<List<Poi>> GetAllAsync(string? fClass, GeoJsonGeometry<GeoJson2DCoordinates>? areaGeometry, double lat, double lon, double distance) {
        var builder = Builders<Poi>.Filter;

        var fClassFilter = !string.IsNullOrEmpty(fClass)
            ? builder.Eq(x => x.Properties.Fclass, fClass)
            : null;

        var areaFilter = areaGeometry is not null
            ? builder.GeoWithin(x => x.Geometry, areaGeometry)
            : null;

        var nearFilter = builder.NearSphere(x => x.Geometry, GeoJson.Point(GeoJson.Position(lon, lat)), distance);

        FilterDefinition<Poi> filter;
        if (string.IsNullOrEmpty(fClass) && areaGeometry is null) {
            filter = nearFilter;
        } else if (string.IsNullOrEmpty(fClass)) {
            filter = areaFilter;
        } else if (areaGeometry is null) {
            filter = builder.And(nearFilter, fClassFilter);
        } else {
            filter = builder.And(areaFilter, fClassFilter);
        }
        return await _context.Poi.Find(filter).ToListAsync();
    }
}