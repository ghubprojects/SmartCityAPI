using MongoDB.Driver.GeoJsonObjectModel;
using SmartCity.Application.Abstractions.Repositories.GisOsm;
using SmartCity.Application.Abstractions.Services;
using System.Globalization;

namespace SmartCity.Application.Services;

public class GeometryService(IGadmRepository gadmRepository) : IGeometryService {
    private readonly IGadmRepository _gadmRepository = gadmRepository;

    public async Task<GeoJsonGeometry<GeoJson2DCoordinates>?> GetGeometryAsync(string area, double lat, double lon) {
        area = NormalizeName(area);
        const char separator = ',';
        if (area.Contains(separator)) {
            var parts = area.Split(separator, StringSplitOptions.TrimEntries);
            return await _gadmRepository.GetGeometryLv2Async(parts[0], parts[1], lat, lon);
        }
        return await _gadmRepository.GetGeometryLv1Async(area, lat, lon) ?? await _gadmRepository.GetGeometryLv2Async(area, null, lat, lon);
    }

    private static string NormalizeName(string str) {
        return CultureInfo.InvariantCulture.TextInfo.ToTitleCase(str).Replace(" ", "");
    }
}
