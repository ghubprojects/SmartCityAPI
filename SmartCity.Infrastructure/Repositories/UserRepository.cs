using Microsoft.EntityFrameworkCore;
using SmartCity.Application.Abstractions.Repositories;
using SmartCity.Domain.Entities;
using SmartCity.Infrastructure.DataContext;

namespace SmartCity.Infrastructure.Repositories;

public class UserRepository(AppDbContext context) : IUserRepository {
    private readonly AppDbContext _context = context;

    public async Task<bool> IsExistAsync(int userId) {
        return await _context.MUsers.AnyAsync(u => u.UserId == userId);
    }

    public async Task<MUser?> GetUserAsync(string username) {
        return await _context.MUsers
            .Include(x => x.Avatar)
            .SingleOrDefaultAsync(u => u.Username == username);
    }

    public async Task AddUserAsync(MUser user) {
        var lastId = await _context.MUsers.MaxAsync(u => u.UserId);
        user.UserId = lastId + 1;
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