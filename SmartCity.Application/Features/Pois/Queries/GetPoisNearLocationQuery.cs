using MediatR;
using SmartCity.Application.Abstractions.Repositories;
using SmartCity.Application.Abstractions.Repositories.GisOsm;
using SmartCity.Application.Features.Pois.DTOs;

namespace SmartCity.Application.Features.Pois.Queries;

public class GetPoisNearLocationQuery : IRequest<List<PoiDetailDto>> {
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public double Radius { get; set; }
}

public class GetPoisNearLocationQueryHandler(
    IGisOsmPoiRepository gisOsmPoiRepository,
    IPoiDetailRepository poiDetailRepository)
    : IRequestHandler<GetPoisNearLocationQuery, List<PoiDetailDto>> {
    private readonly IGisOsmPoiRepository _gisOsmPoiRepository = gisOsmPoiRepository;
    private readonly IPoiDetailRepository _poiDetailRepository = poiDetailRepository;

    public async Task<List<PoiDetailDto>> Handle(GetPoisNearLocationQuery request, CancellationToken cancellationToken) {
        var pois = await _gisOsmPoiRepository.GetPoisNearLocation(request.Latitude, request.Longitude, request.Radius);
        var ids = pois.Select(x => x.Gid).ToList();
        var poiDetails = await _poiDetailRepository.GetPoiDetailsByGidsAsync(ids);
        return poiDetails.Select(x => new PoiDetailDto(x)).ToList();
    }
}
