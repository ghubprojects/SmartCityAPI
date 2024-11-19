using MongoDB.Driver.GeoJsonObjectModel;
using SmartCity.Application.Abstractions.Repositories.GisOsm;
using SmartCity.Application.Abstractions.Services;

namespace SmartCity.Application.Services;

public class GeometryService(IGadmRepository gadmRepository) : IGeometryService {
    private readonly IGadmRepository _gadmRepository = gadmRepository;

    public async Task<GeoJsonGeometry<GeoJson2DCoordinates>?> GetGeometryAsync(string keyword, double lat, double lon) {
        const char separator = ',';
        if (keyword.Contains(separator)) {
            var parts = keyword.Split(separator, StringSplitOptions.TrimEntries);
            return await _gadmRepository.GetGeometryLv2Async(parts[0], parts[1], lat, lon);
        }
        return await _gadmRepository.GetGeometryLv1Async(keyword, lat, lon) ?? await _gadmRepository.GetGeometryLv2Async(keyword, null, lat, lon);
    }
}
