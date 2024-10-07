using AutoMapper;
using SmartCity.Application.Abstractions.Repositories;
using SmartCity.Application.Abstractions.Repositories.GisOsm;
using SmartCity.Application.Abstractions.Services;
using SmartCity.Application.DTOs;

namespace SmartCity.Application.Services;
public class PoiService(
    IMapper mapper,
    IOsmPoiRepository gisOsmPoiRepository,
    IPoiDetailRepository poiDetailRepository) : IPoiService {
    private readonly IMapper _mapper = mapper;
    private readonly IOsmPoiRepository _osmPoiRepository = gisOsmPoiRepository;
    private readonly IPoiDetailRepository _poiDetailRepository = poiDetailRepository;

    public async Task<List<PoiDetailDto>> GetPoisNearLocation(double lat, double lon, double distance) {
        var pois = await _osmPoiRepository.GetNearSphereAsync(lat, lon, distance);
        var ids = pois.Select(x => x.Properties.OsmId).ToList();
        var poiDetails = await _poiDetailRepository.GetDataListAsync(ids);
        return _mapper.Map<List<PoiDetailDto>>(poiDetails);
    }
}
