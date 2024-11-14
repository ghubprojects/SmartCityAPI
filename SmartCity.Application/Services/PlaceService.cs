using AutoMapper;
using MongoDB.Driver.GeoJsonObjectModel;
using SmartCity.Application.Abstractions.Repositories;
using SmartCity.Application.Abstractions.Repositories.GisOsm;
using SmartCity.Application.Abstractions.Services;
using SmartCity.Application.DTOs;

namespace SmartCity.Application.Services;

public class PlaceService(
    IMapper mapper,
    IPoiRepository gisPlaceRepository,
    IPlaceDetailRepository poiDetailRepository) : IPlaceService {
    private readonly IMapper _mapper = mapper;
    private readonly IPoiRepository _poiRepository = gisPlaceRepository;
    private readonly IPlaceDetailRepository _poiDetailRepository = poiDetailRepository;

    public async Task<List<PlaceDetailDto>> GetPlacesNearLocationAsync(double lat, double lon, string type, double distance) {
        var pois = await _poiRepository.GetNearSphereAsync(lat, lon, type, distance);
        if (pois.Count == 0) {
            return [];
        }

        var osmIds = pois.Select(x => x.Properties.OsmId).ToList();
        var poiDetails = await _poiDetailRepository.GetDataListAsync(osmIds);
        var poiDetailsDict = poiDetails
            .GroupBy(p => p.OsmId)
            .ToDictionary(g => g.Key, g => g.First());
        var poiDetailDtos = pois.Select(poi => {
            var dto = _mapper.Map<PlaceDetailDto>(poi);
            if (poiDetailsDict.TryGetValue(poi.Properties.OsmId, out var poiDetail)) {
                _mapper.Map(poiDetail, dto);
            }
            return dto;
        }).ToList();
        return poiDetailDtos;
    }
}
