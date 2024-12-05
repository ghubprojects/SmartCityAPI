using Microsoft.AspNetCore.Http;
using SmartCity.Application.Abstractions.Repositories;
using SmartCity.Application.Abstractions.Services;
using SmartCity.Application.DTOs;

namespace SmartCity.Application.Services;

public class UserService(IUserRepository userRepository) : IUserService {
    private readonly IUserRepository _userRepository = userRepository;

    public async Task<UserDto> GetUserAsync(string username) {
        var user = await _userRepository.GetUserAsync(username)
            ?? throw new BadHttpRequestException("Người dùng không tồn tại.");

        return new UserDto(user);
    }
}
