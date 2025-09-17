using Domain;

namespace Application.Common.Interfaces.Persistance.Repositories;

public interface IUserRepository : IRepository<int>
{
    Task<User?> GetUserByIdAsync(int userId);
}
