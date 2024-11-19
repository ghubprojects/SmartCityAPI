using SmartCity.Application.Abstractions.Repositories;
using SmartCity.Application.Abstractions.Repositories.GisOsm;
using SmartCity.Application.Abstractions.Services;
using SmartCity.Application.DTOs;

namespace SmartCity.Application.Services;

public class PlaceService(
    IPoiRepository poiRepository,
    IPlaceDetailRepository poiDetailRepository,
    IGeometryService geometryService) : IPlaceService {
    private readonly IPoiRepository _poiRepository = poiRepository;
    private readonly IPlaceDetailRepository _poiDetailRepository = poiDetailRepository;
    private readonly IGeometryService _geometryService = geometryService;

    public async Task<List<PlaceDetailDto>> GetPlacesAsync(string keyword, double lat, double lon, double distance) {
        var geometry = await _geometryService.GetGeometryAsync(keyword, lat, lon);

        var pois = geometry is not null
            ? await _poiRepository.GetWithinAreaAsync(geometry)
            : await _poiRepository.GetNearSphereAsync(lat, lon, keyword, distance);

        if (pois.Count == 0) {
            return [];
        }

        var osmIds = pois.Select(x => x.Properties.OsmId).ToList();
        var poiDetails = await _poiDetailRepository.GetDataListAsync(osmIds);
        var poiDetailsDict = poiDetails
            .GroupBy(p => p.OsmId)
            .ToDictionary(g => g.Key, g => g.First());

        var result = new List<PlaceDetailDto>();
        foreach (var poi in pois) {
            if (poiDetailsDict.TryGetValue(poi.Properties.OsmId, out var poiDetail)) {
                result.Add(new PlaceDetailDto(poi, poiDetail));
            }
        }

        return result;
    }
}
