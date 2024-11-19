using MongoDB.Driver;
using MongoDB.Driver.GeoJsonObjectModel;
using SmartCity.Application.Abstractions.Repositories.GisOsm;
using SmartCity.Domain.Entities.GisOsm;
using SmartCity.Infrastructure.DataContext;

namespace SmartCity.Infrastructure.Repositories.GisOsm;

public class GadmRepository(GisOsmContext context) : IGadmRepository {
    private const int MAX_DISTANCE = 2000000;
    private readonly GisOsmContext _context = context;

    public async Task<GeoJsonGeometry<GeoJson2DCoordinates>?> GetGeometryLv1Async(string name1, double? lat = null, double? lon = null) {
        var builder = Builders<GadmLv1>.Filter;
        var typeFilter = builder.Eq(x => x.Properties.Name1, name1);

        FilterDefinition<GadmLv1> filter = typeFilter;
        if (lat.HasValue && lon.HasValue) {
            var location = GeoJson.Point(GeoJson.Position(lon.Value, lat.Value));
            var nearSphereFilter = builder.NearSphere(x => x.Geometry, location, MAX_DISTANCE);
            filter = builder.And(typeFilter, nearSphereFilter);
        }

        var gadmLv1List = await _context.GadmLv1.Find(filter).ToListAsync();
        return gadmLv1List.FirstOrDefault()?.Geometry;
    }

    public async Task<GeoJsonGeometry<GeoJson2DCoordinates>?> GetGeometryLv2Async(string name2, string? name1 = null, double? lat = null, double? lon = null) {
        var builder = Builders<GadmLv2>.Filter;
        var typeFilter = !string.IsNullOrEmpty(name1)
            ? builder.Eq(x => x.Properties.Name1, name1) & builder.Eq(x => x.Properties.Name2, name2)
            : builder.Eq(x => x.Properties.Name2, name2);

        FilterDefinition<GadmLv2> filter = typeFilter;
        if (lat.HasValue && lon.HasValue) {
            var location = GeoJson.Point(GeoJson.Position(lon.Value, lat.Value));
            var nearSphereFilter = builder.NearSphere(x => x.Geometry, location, MAX_DISTANCE);
            filter = builder.And(typeFilter, nearSphereFilter);
        }

        var gadmLv2List = await _context.GadmLv2.Find(filter).ToListAsync();
        return gadmLv2List.FirstOrDefault()?.Geometry;
    }
}