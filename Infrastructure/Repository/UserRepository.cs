using Application.Common.Interfaces;
using Domain;
using Infrastucture;

namespace Infrastructure.Repository;

public class UserRepository : IUserRepository
{
    private readonly DataContext _context = new DataContext();

    public async Task<User?> GetUserByIdAsync(string userId)
    {
        await Task.Delay(10);
        return _context.Users
            .FirstOrDefault(x => x.UserId == userId);
    }
}
