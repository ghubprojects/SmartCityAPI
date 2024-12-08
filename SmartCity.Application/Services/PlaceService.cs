using SmartCity.Application.Abstractions.Repositories;
using SmartCity.Application.Abstractions.Repositories.GisOsm;
using SmartCity.Application.Abstractions.Services;
using SmartCity.Application.DTOs;

namespace SmartCity.Application.Services;

public class PlaceService(
    IPoiRepository poiRepository,
    IPlaceDetailRepository poiDetailRepository,
    IPlaceTypeRepository placeTypeRepository,
    IGeometryService geometryService) : IPlaceService {
    private readonly IPoiRepository _poiRepository = poiRepository;
    private readonly IPlaceDetailRepository _poiDetailRepository = poiDetailRepository;
    private readonly IPlaceTypeRepository _placeTypeRepository = placeTypeRepository;
    private readonly IGeometryService _geometryService = geometryService;

    public async Task<List<PlaceDetailDto>> GetPlacesAsync(string? type, string? area, double lat, double lon, double distance) {
        var areaGeometry = !string.IsNullOrEmpty(area)
            ? await _geometryService.GetGeometryAsync(area, lat, lon)
            : null;
        if (!string.IsNullOrEmpty(area) && areaGeometry is null) {
            return [];
        }

        var fClass = !string.IsNullOrEmpty(type)
            ? await _placeTypeRepository.GetFClassAsync(type)
            : null;

        var pois = await _poiRepository.GetAllAsync(fClass, areaGeometry, lat, lon, distance);
        if (pois.Count == 0) {
            return [];
        }

        var osmIds = pois.Select(x => x.Properties.OsmId).ToList();
        var poiDetails = await _poiDetailRepository.GetDataListAsync(osmIds);
        var poiDetailsDict = poiDetails
            .GroupBy(p => p.OsmId)
            .ToDictionary(g => g.Key, g => g.First());

        var placeTypeDict = await _placeTypeRepository.GetTypeDictAsync();

        var result = new List<PlaceDetailDto>();
        pois = [.. pois.OrderByDescending(x => x.Properties.Name)];
        foreach (var poi in pois) {
            if (poiDetailsDict.TryGetValue(poi.Properties.OsmId, out var poiDetail)) {
                result.Add(new PlaceDetailDto(poi, poiDetail, placeTypeDict));
            }
        }

        return result;
    }

    public async Task<List<string>> GetTypesAsync() {
        var placeTypeDict = await _placeTypeRepository.GetTypeDictAsync();
        return [.. placeTypeDict.Values.Distinct()];
    }
}
