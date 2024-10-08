using MediatR;
using SmartCity.Application.Abstractions.Services;
using SmartCity.Application.DTOs;

namespace SmartCity.Application.Features.Pois;

public class GetPoisNearLocationQuery : IRequest<List<PoiDetailDto>> {
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public string Type { get; set; } = string.Empty;
    public double Distance { get; set; }
}

public class GetPoisNearLocationQueryHandler(IPoiService poiService) : IRequestHandler<GetPoisNearLocationQuery, List<PoiDetailDto>> {
    private readonly IPoiService _poiService = poiService;

    public async Task<List<PoiDetailDto>> Handle(GetPoisNearLocationQuery request, CancellationToken cancellationToken) {
        return await _poiService.GetPoisNearLocation(request.Latitude, request.Longitude, request.Type, request.Distance);
    }
}
