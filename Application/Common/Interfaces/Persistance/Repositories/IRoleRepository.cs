using Domain;

namespace Application.Common.Interfaces.Persistance.Repositories;

public interface IRoleRepository
{
    Task<int> CreateRoleAsync(string roleName);
    Task<Role?> GetRoleByNameAsync(string roleName);
}
