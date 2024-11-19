using MongoDB.Driver.GeoJsonObjectModel;

namespace SmartCity.Application.Abstractions.Repositories.GisOsm;

public interface IGadmRepository {
    Task<GeoJsonGeometry<GeoJson2DCoordinates>?> GetGeometryLv1Async(string name1, double? lat = null, double? lon = null);
    Task<GeoJsonGeometry<GeoJson2DCoordinates>?> GetGeometryLv2Async(string name2, string? name1, double? lat = null, double? lon = null);
}
