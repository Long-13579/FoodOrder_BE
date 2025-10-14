using Application.Common.Models;
using Application.Common.Results;

namespace Application.Common.Interfaces.Persistance.Repositories;

public interface IRoleRepository : IRepository<Guid>
{
    Task<Result> CreateRoleAsync(RoleDTO role);
    Task<Result<RoleDTO>> GetRoleByNameAsync(string roleName);
}
