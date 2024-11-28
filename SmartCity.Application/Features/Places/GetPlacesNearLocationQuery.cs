using MediatR;
using SmartCity.Application.Abstractions.Services;
using SmartCity.Application.DTOs;

namespace SmartCity.Application.Features.Places;

public class GetPlacesNearLocationQuery : IRequest<List<PlaceDetailDto>> {
    public string? Type { get; set; }
    public string? Area { get; set; }
    public double Latitude { get; set; } = 21.028;
    public double Longitude { get; set; } = 105.852;
    public double Distance { get; set; } = 2000;
}

public class GetPlacesNearLocationQueryHandler(IPlaceService placeService) : IRequestHandler<GetPlacesNearLocationQuery, List<PlaceDetailDto>> {
    private readonly IPlaceService _placeService = placeService;

    public async Task<List<PlaceDetailDto>> Handle(GetPlacesNearLocationQuery request, CancellationToken cancellationToken) {
        return await _placeService.GetPlacesAsync(request.Type, request.Area, request.Latitude, request.Longitude, request.Distance);
    }
}
