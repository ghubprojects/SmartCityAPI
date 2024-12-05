using FluentValidation;
using MediatR;
using SmartCity.Application.Abstractions.Services;
using SmartCity.Application.DTOs;

namespace SmartCity.Application.Features.Users;

public class GetUserRequest : IRequest<UserDto> {
    public string Username { get; set; } = string.Empty;
}

public class GetUserRequestHandler(IUserService userService) : IRequestHandler<GetUserRequest, UserDto> {
    private readonly IUserService _userService = userService;

    public async Task<UserDto> Handle(GetUserRequest request, CancellationToken cancellationToken) {
        await new GetUserRequestValidator().ValidateAndThrowAsync(request, cancellationToken);
        return await _userService.GetUserAsync(request.Username);
    }
}

public class GetUserRequestValidator : AbstractValidator<GetUserRequest> {
    public GetUserRequestValidator() {
        RuleFor(x => x.Username)
            .NotEmpty().WithMessage("Tên người dùng không được để trống.")
            .MinimumLength(3).WithMessage("Tên người dùng phải có ít nhất 3 ký tự.")
            .MaximumLength(50).WithMessage("Tên người dùng không được vượt quá 50 ký tự.");
    }
}