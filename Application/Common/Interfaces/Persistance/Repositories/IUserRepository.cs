using Application.Common.Models;
using Application.Common.Results;

namespace Application.Common.Interfaces.Persistance.Repositories;

public interface IUserRepository : IRepository<Guid>
{
    Task<Result<UserDTO>> GetUserByIdAsync(Guid userId);
    Task<Result<UserDTO>> GetUserByUserNameAsync(string userName);
    Task<Result<UserDTO>> GetUserByEmailAsync(string email);
    Task<Result> CreateUserAsync(UserDTO user, string password);
    Task<Result<UserDTO>> AuthenticateAsync(string userName, string password);
    Task<Result> AssignRoleToUserAsync(Guid userId, string roleName);
    Task<Result> RemoveRoleFromUserAsync(Guid userId, string roleName);
    Task<Result<List<string>>> GetRolesByUserIdAsync(Guid userId);
}
