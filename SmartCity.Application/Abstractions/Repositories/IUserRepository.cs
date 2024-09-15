using SmartCity.Domain.Entities;

namespace SmartCity.Application.Abstractions.Repositories;

public interface IUserRepository {
    Task<User?> GetUserByIdAsync(int userId);
    Task<User?> GetUserByUsernameAsync(string username);
    Task AddUserAsync(User user);
    Task UpdateUserAsync(User user);
    Task DeleteUserAsync(int userId);
}