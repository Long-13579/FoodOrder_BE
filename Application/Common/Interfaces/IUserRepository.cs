using Domain;

namespace Application.Common.Interfaces;

public interface IUserRepository
{
    Task<User?> GetUserByIdAsync(string userId);
}
