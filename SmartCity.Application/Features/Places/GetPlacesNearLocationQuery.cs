using MediatR;
using SmartCity.Application.Abstractions.Services;
using SmartCity.Application.DTOs;

namespace SmartCity.Application.Features.Places;

public class GetPlacesNearLocationQuery : IRequest<List<PlaceDetailDto>> {
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public string Type { get; set; } = string.Empty;
    public double Distance { get; set; }
}

public class GetPlacesNearLocationQueryHandler(IPlaceService poiService) : IRequestHandler<GetPlacesNearLocationQuery, List<PlaceDetailDto>> {
    private readonly IPlaceService _poiService = poiService;

    public async Task<List<PlaceDetailDto>> Handle(GetPlacesNearLocationQuery request, CancellationToken cancellationToken) {
        return await _poiService.GetPlacesNearLocationAsync(request.Latitude, request.Longitude, request.Type, request.Distance);
    }
}
