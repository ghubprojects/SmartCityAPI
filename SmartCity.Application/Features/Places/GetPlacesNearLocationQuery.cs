using MediatR;
using SmartCity.Application.Abstractions.Services;
using SmartCity.Application.DTOs;

namespace SmartCity.Application.Features.Places;

public class GetPlacesNearLocationQuery : IRequest<List<PlaceDetailDto>> {
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public string Keyword { get; set; } = string.Empty;
    public double Distance { get; set; }
}

public class GetPlacesNearLocationQueryHandler(IPlaceService poiService) : IRequestHandler<GetPlacesNearLocationQuery, List<PlaceDetailDto>> {
    private readonly IPlaceService _poiService = poiService;

    public async Task<List<PlaceDetailDto>> Handle(GetPlacesNearLocationQuery request, CancellationToken cancellationToken) {
        return await _poiService.GetPlacesAsync(request.Keyword, request.Latitude, request.Longitude, request.Distance);
    }
}
