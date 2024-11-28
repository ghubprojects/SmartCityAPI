using SmartCity.Application.Abstractions.Providers;
using SmartCity.Application.Abstractions.Repositories;
using SmartCity.Application.Abstractions.Services;
using SmartCity.Domain.Entities;

namespace SmartCity.Application.Services;

public class AuthService(IUserRepository userRepository, IJwtProvider jwtProvider) : IAuthService {
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IJwtProvider _jwtProvider = jwtProvider;

    public async Task<string> Login(string username, string password) {
        var user = await _userRepository.GetUserByUsernameAsync(username);
        if (user is null || !BCrypt.Net.BCrypt.Verify(password, user.PasswordHash)) {
            throw new UnauthorizedAccessException("Invalid username or password.");
        }

        var token = _jwtProvider.GenerateToken(user);
        return token;
    }

    public async Task Register(string username, string password, string email) {
        var existingUser = await _userRepository.GetUserByUsernameAsync(username);
        if (existingUser is not null)
            throw new UnauthorizedAccessException("Username already exists");

        var passwordHash = BCrypt.Net.BCrypt.HashPassword(password);
        var user = new MUser {
            Username = username,
            PasswordHash = passwordHash,
            Email = email
        };
        await _userRepository.AddUserAsync(user);
    }
}
