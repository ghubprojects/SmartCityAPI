using FluentValidation;
using MediatR;
using SmartCity.Application.Abstractions.Services;
using SmartCity.Application.DTOs;

namespace SmartCity.Application.Features.Reviews;

public class AddReviewRequest : IRequest<Unit> {
    public int PlaceId { get; set; }
    public int UserId { get; set; }
    public int Rating { get; set; }
    public string Comment { get; set; } = string.Empty;
}

public class AddReviewRequestHandler(IReviewService reviewService) : IRequestHandler<AddReviewRequest, Unit> {
    private readonly IReviewService _reviewService = reviewService;

    public async Task<Unit> Handle(AddReviewRequest request, CancellationToken cancellationToken) {
        await new AddReviewRequestValidator().ValidateAndThrowAsync(request, cancellationToken);
        await _reviewService.AddReviewAsync(request.PlaceId, request.UserId, request.Rating, request.Comment);
        return Unit.Value;
    }
}

public class AddReviewRequestValidator : AbstractValidator<AddReviewRequest> {
    public AddReviewRequestValidator() {
        RuleFor(x => x.PlaceId)
            .GreaterThan(0).WithMessage("Địa điểm không hợp lệ.");

        RuleFor(x => x.UserId)
            .GreaterThan(0).WithMessage("Người dùng không hợp lệ.");

        RuleFor(x => x.Rating)
            .InclusiveBetween(1, 5).WithMessage("Điểm đánh giá phải nằm trong khoảng từ 1 đến 5.");

        RuleFor(x => x.Comment)
            .NotEmpty().WithMessage("Bình luận không được để trống.")
            .MaximumLength(500).WithMessage("Bình luận không được vượt quá 500 ký tự.");
    }
}