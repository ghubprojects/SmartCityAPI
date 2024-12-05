using MediatR;
using SmartCity.Application.Abstractions.Services;

namespace SmartCity.Application.Features.Places;

public class GetPlaceTypesRequest : IRequest<List<string>> { }

public class GetPlaceTypesRequestHandler(IPlaceService placeService) : IRequestHandler<GetPlaceTypesRequest, List<string>> {
    private readonly IPlaceService _placeService = placeService;

    public async Task<List<string>> Handle(GetPlaceTypesRequest request, CancellationToken cancellationToken) {
        return await _placeService.GetTypesAsync();
    }
}
