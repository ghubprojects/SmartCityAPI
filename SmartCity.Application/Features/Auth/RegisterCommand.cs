using MediatR;
using SmartCity.Application.Abstractions.Services;

namespace SmartCity.Application.Features.Auth;

public class RegisterCommand : IRequest<Unit> {
    public string Username { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
}

public class RegisterCommandHandler(IAuthService authService) : IRequestHandler<RegisterCommand, Unit> {
    private readonly IAuthService _authService = authService;

    public async Task<Unit> Handle(RegisterCommand request, CancellationToken cancellationToken) {
        await _authService.Register(request.Username, request.Password, request.Email);
        return Unit.Value;
    }
}