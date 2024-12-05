using SmartCity.Domain.Entities;

namespace SmartCity.Application.Abstractions.Repositories;

public interface IUserRepository {
    Task<bool> IsExistAsync(int userId);
    Task<MUser?> GetUserAsync(string username);
    Task AddUserAsync(MUser user);
    Task UpdateUserAsync(MUser user);
    Task DeleteUserAsync(int userId);
}