using SmartCity.Domain.Entities;

namespace SmartCity.Application.Abstractions.Repositories;

public interface IUserRepository {
    Task<MUser?> GetUserByIdAsync(int userId);
    Task<MUser?> GetUserByUsernameAsync(string username);
    Task AddUserAsync(MUser user);
    Task UpdateUserAsync(MUser user);
    Task DeleteUserAsync(int userId);
}