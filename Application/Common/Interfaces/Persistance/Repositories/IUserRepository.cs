using Domain;

namespace Application.Common.Interfaces.Persistance.Repositories;

public interface IUserRepository : IRepository<Guid>
{
    Task<User?> GetUserByIdAsync(Guid userId);
    Task<User?> GetUserByUserNameAsync(string userName);
    Task AddUserAsync(User user);
    Task AssignRoleToUserAsync(Guid userId, int roleId);
    Task RemoveRoleFromUserAsync(Guid userId, int roleId);
    Task<List<Role>> GetRolesByUserIdAsync(Guid userId);
}
