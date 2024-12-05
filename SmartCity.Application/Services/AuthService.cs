using Microsoft.AspNetCore.Http;
using SmartCity.Application.Abstractions.Providers;
using SmartCity.Application.Abstractions.Repositories;
using SmartCity.Application.Abstractions.Services;
using SmartCity.Application.DTOs;
using SmartCity.Domain.Entities;

namespace SmartCity.Application.Services;

public class AuthService(IUserRepository userRepository, IJwtProvider jwtProvider) : IAuthService {
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IJwtProvider _jwtProvider = jwtProvider;

    public async Task<LoginDto> Login(string username, string password) {
        var user = await _userRepository.GetUserAsync(username);
        if (user is null || !BCrypt.Net.BCrypt.Verify(password, user.PasswordHash)) {
            throw new BadHttpRequestException("Tên đăng nhập hoặc mật khẩu không đúng.");
        }

        var token = _jwtProvider.GenerateToken(user);
        return new LoginDto(user, token);
    }

    public async Task Register(string username, string password, string email) {
        var user = await _userRepository.GetUserAsync(username);
        if (user is not null)
            throw new BadHttpRequestException("Người dùng đã tồn tại.");

        var passwordHash = BCrypt.Net.BCrypt.HashPassword(password);
        var newUser = new MUser {
            Username = username,
            PasswordHash = passwordHash,
            Email = email
        };
        await _userRepository.AddUserAsync(newUser);
    }
}
