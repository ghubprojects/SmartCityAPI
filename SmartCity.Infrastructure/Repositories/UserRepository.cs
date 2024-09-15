using Microsoft.EntityFrameworkCore;
using SmartCity.Application.Abstractions.Repositories;
using SmartCity.Domain.Entities;
using SmartCity.Infrastructure.DataContext;

namespace SmartCity.Infrastructure.Repositories;

public class UserRepository(SmartCityContext context) : IUserRepository {
    private readonly SmartCityContext _context = context;

    public async Task<User?> GetUserByIdAsync(int userId) {
        return await _context.Users
            .FirstOrDefaultAsync(u => u.UserId.Equals(userId) && !u.DeleteFlag);
    }

    public async Task<User?> GetUserByUsernameAsync(string username) {
        return await _context.Users
            .FirstOrDefaultAsync(u => u.Username.Equals(username) && !u.DeleteFlag);
    }

    public async Task AddUserAsync(User user) {
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateUserAsync(User user) {
        _context.Users.Update(user);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteUserAsync(int userId) {
        var user = await _context.Users.FindAsync(userId);
        if (user != null) {
            user.DeleteFlag = true;
            await _context.SaveChangesAsync();
        }
    }
}