using Application.Common.Interfaces.Persistance.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistance.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;

    public UserRepository(AppDbContext dbContext)
    {
        _context = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    public async Task AddUserAsync(User user)
    {
        await _context.Users.AddAsync(user);
    }

    public async Task AssignRoleToUserAsync(Guid userId, int roleId)
    {
        await _context.UserRoles.AddAsync(new UserRole
        {
            UserId = userId,
            RoleId = roleId,
            AssignedAt = DateTime.UtcNow
        });
    }

    public Task<bool> ExistsAsync(Guid id)
    {
        return _context.Users.AnyAsync(x => x.Id == id);
    }

    public async Task<List<Role>> GetRolesByUserIdAsync(Guid userId)
    {
        return await _context.UserRoles
            .Where(ur => ur.UserId == userId)
            .Include(ur => ur.Role)
            .Select(ur => ur.Role)
            .ToListAsync();
    }

    public async Task<User?> GetUserByIdAsync(Guid userId)
    {
        return await _context.Users
            .FirstOrDefaultAsync(x => x.Id == userId);
    }

    public Task<User?> GetUserByUserNameAsync(string userName)
    {
        return _context.Users
            .FirstOrDefaultAsync(x => x.UserName == userName);
    }

    public async Task RemoveRoleFromUserAsync(Guid userId, int roleId)
    {
        await _context.UserRoles
            .Where(ur => ur.UserId == userId && ur.RoleId == roleId)
            .ExecuteDeleteAsync();
    }
}
