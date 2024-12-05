using FluentValidation;
using MediatR;
using SmartCity.Application.Abstractions.Services;
using SmartCity.Application.DTOs;

namespace SmartCity.Application.Features.Places;

public class GetPlaceRequest : IRequest<List<PlaceDetailDto>> {
    public string? Type { get; set; }
    public string? Area { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public double Distance { get; set; }
}

public class GetPlacesRequestHandler(IPlaceService placeService) : IRequestHandler<GetPlaceRequest, List<PlaceDetailDto>> {
    private readonly IPlaceService _placeService = placeService;

    public async Task<List<PlaceDetailDto>> Handle(GetPlaceRequest request, CancellationToken cancellationToken) {
        await new GetPlaceRequestValidator().ValidateAndThrowAsync(request, cancellationToken);
        return await _placeService.GetPlacesAsync(request.Type, request.Area, request.Latitude, request.Longitude, request.Distance);
    }
}

public class GetPlaceRequestValidator : AbstractValidator<GetPlaceRequest> {
    public GetPlaceRequestValidator() {
        RuleFor(x => x.Type)
            .MaximumLength(255).WithMessage("Loại địa điểm không được vượt quá 255 ký tự.");

        RuleFor(x => x.Area)
            .MaximumLength(100).WithMessage("Khu vực tìm kiếm không được vượt quá 100 ký tự.");

        RuleFor(x => x.Latitude)
            .InclusiveBetween(-90, 90).WithMessage("Vĩ độ phải nằm trong khoảng từ -90 đến 90.");

        RuleFor(x => x.Longitude)
            .InclusiveBetween(-180, 180).WithMessage("Kinh độ phải nằm trong khoảng từ -180 đến 180.");

        RuleFor(x => x.Distance / 1000)
            .GreaterThan(0).WithMessage("Bán kính tìm kiếm phải lớn hơn 0.")
            .LessThanOrEqualTo(100).WithMessage("Bán kính tìm kiếm không được vượt quá 100 km.");
    }
}