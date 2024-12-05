using SmartCity.Application.DTOs;

namespace SmartCity.Application.Abstractions.Services;

public interface IAuthService {
    Task<LoginDto> Login(string username, string password);
    Task Register(string username, string password, string email);
}
