using SmartCity.Application.DTOs;

namespace SmartCity.Application.Abstractions.Services;

public interface IUserService {
    Task<UserDto> GetUserAsync(string username);
}
