using MediatR;
using SmartCity.Application.Abstractions.Services;

namespace SmartCity.Application.Features.Auth;
public class LoginQuery : IRequest<string> {
    public string Username { get; set; }
    public string Password { get; set; }
}

public class LoginQueryHandler(IAuthService authService) : IRequestHandler<LoginQuery, string> {
    private readonly IAuthService _authService = authService;

    public async Task<string> Handle(LoginQuery request, CancellationToken cancellationToken) {
        var accessToken = await _authService.Login(request.Username, request.Password);
        return accessToken;
    }
}