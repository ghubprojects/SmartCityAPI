using FluentValidation;
using MediatR;
using SmartCity.Application.Abstractions.Services;

namespace SmartCity.Application.Features.Auth;

public class RegisterRequest : IRequest<Unit> {
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}

public class RegisterRequestHandler(IAuthService authService) : IRequestHandler<RegisterRequest, Unit> {
    private readonly IAuthService _authService = authService;

    public async Task<Unit> Handle(RegisterRequest request, CancellationToken cancellationToken) {
        await new RegisterRequestValidator().ValidateAndThrowAsync(request, cancellationToken);
        await _authService.Register(request.Username, request.Password, request.Email);
        return Unit.Value;
    }
}

public class RegisterRequestValidator : AbstractValidator<RegisterRequest> {
    public RegisterRequestValidator() {
        RuleFor(x => x.Username)
            .NotEmpty().WithMessage("Tên người dùng không được để trống.")
            .MinimumLength(3).WithMessage("Tên người dùng phải có ít nhất 3 ký tự.")
            .MaximumLength(50).WithMessage("Tên người dùng không được vượt quá 50 ký tự.");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Mật khẩu không được để trống.")
            .MinimumLength(6).WithMessage("Mật khẩu phải có ít nhất 6 ký tự.")
            .Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{6,}$")
            .WithMessage("Mật khẩu phải bao gồm ít nhất 1 chữ hoa, 1 chữ thường, 1 chữ số và 1 ký tự đặc biệt.");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email không được để trống.")
            .EmailAddress().WithMessage("Email phải đúng định dạng.");
    }
}