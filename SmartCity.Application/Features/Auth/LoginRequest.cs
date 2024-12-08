using FluentValidation;
using MediatR;
using SmartCity.Application.Abstractions.Services;
using SmartCity.Application.DTOs;

namespace SmartCity.Application.Features.Auth;
public class LoginRequest : IRequest<LoginDto> {
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}

public class LoginRequestHandler(IAuthService authService) : IRequestHandler<LoginRequest, LoginDto> {
    private readonly IAuthService _authService = authService;

    public async Task<LoginDto> Handle(LoginRequest request, CancellationToken cancellationToken) {
        await new LoginRequestValidator().ValidateAndThrowAsync(request, cancellationToken);
        return await _authService.Login(request.Username, request.Password);
    }
}

public class LoginRequestValidator : AbstractValidator<LoginRequest> {
    public LoginRequestValidator() {
        RuleFor(x => x.Username).NotEmpty().WithMessage("Tên người dùng không được để trống.");
        RuleFor(x => x.Password).NotEmpty().WithMessage("Mật khẩu không được để trống.");
    }
}