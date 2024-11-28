using MongoDB.Driver.GeoJsonObjectModel;

namespace SmartCity.Application.Abstractions.Services;

public interface IGeometryService {
    Task<GeoJsonGeometry<GeoJson2DCoordinates>?> GetGeometryAsync(string area, double lat, double lon);
}