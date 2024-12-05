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
        RuleFor(x => x.Username)
            .NotEmpty().WithMessage("Tên người dùng không được để trống.")
            .MinimumLength(3).WithMessage("Tên người dùng phải có ít nhất 3 ký tự.");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Mật khẩu không được để trống.")
            .MinimumLength(6).WithMessage("Mật khẩu phải có ít nhất 6 ký tự.")
            .Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{6,}$")
            .WithMessage("Mật khẩu phải bao gồm ít nhất 1 chữ hoa, 1 chữ thường, 1 chữ số và 1 ký tự đặc biệt.");
    }
}