using SmartCity.Application.Abstractions.Repositories;
using SmartCity.Application.Abstractions.Repositories.GisOsm;
using SmartCity.Application.Abstractions.Services;
using SmartCity.Application.DTOs;

namespace SmartCity.Application.Services;

public class PlaceService(
    IPoiRepository gisPlaceRepository,
    IPlaceDetailRepository poiDetailRepository) : IPlaceService {
    private readonly IPoiRepository _poiRepository = gisPlaceRepository;
    private readonly IPlaceDetailRepository _poiDetailRepository = poiDetailRepository;

    public async Task<List<PlaceDetailDto>> GetPlacesNearLocationAsync(double lat, double lon, string type, double distance) {
        var pois = await _poiRepository.GetNearSphereAsync(lat, lon, type, distance);
        if (pois.Count == 0) {
            return [];
        }

        var result = new List<PlaceDetailDto>();
        var osmIds = pois.Select(x => x.Properties.OsmId).ToList();
        var poiDetails = await _poiDetailRepository.GetDataListAsync(osmIds);
        var poiDetailsDict = poiDetails
            .GroupBy(p => p.OsmId)
            .ToDictionary(g => g.Key, g => g.First());

        foreach (var poi in pois) {
            if (poiDetailsDict.TryGetValue(poi.Properties.OsmId, out var poiDetail)) {
                result.Add(new PlaceDetailDto(poi, poiDetail));
            }
        }

        return result;
    }
}
