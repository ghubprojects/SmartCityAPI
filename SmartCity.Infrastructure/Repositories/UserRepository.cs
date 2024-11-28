using Microsoft.EntityFrameworkCore;
using SmartCity.Application.Abstractions.Repositories;
using SmartCity.Domain.Entities;
using SmartCity.Infrastructure.DataContext;

namespace SmartCity.Infrastructure.Repositories;

public class UserRepository(AppDbContext context) : IUserRepository {
    private readonly AppDbContext _context = context;

    public async Task<MUser?> GetUserByIdAsync(int userId) {
        return await _context.MUsers
            .FirstOrDefaultAsync(u => u.UserId.Equals(userId));
    }

    public async Task<MUser?> GetUserByUsernameAsync(string username) {
        return await _context.MUsers.SingleOrDefaultAsync(u => u.Username == username);
    }

    public async Task AddUserAsync(MUser user) {
        _context.MUsers.Add(user);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateUserAsync(MUser user) {
        _context.MUsers.Update(user);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteUserAsync(int userId) {
        var user = await _context.MUsers.FindAsync(userId);
        if (user != null) {
            user.DeleteFlag = true;
            await _context.SaveChangesAsync();
        }
    }
}