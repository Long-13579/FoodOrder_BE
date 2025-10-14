using Application.Common.Interfaces.Persistance.Repositories;
using Application.Common.Models;
using Application.Common.Results;
using Application.Common.Errors;
using Infrastructure.Common.Mappings;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistance.Repositories;

public class UserRepository : IUserRepository
{
    private readonly UserManager<ApplicationUser> _userManager;

    public UserRepository(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
    }

    public async Task<Result> AssignRoleToUserAsync(Guid userId, string roleName)
    {
        var user = await _userManager.FindByIdAsync(userId.ToString());
        if (user is null)
            return Errors.User.NotFound(userId);

        var result = await _userManager.AddToRoleAsync(user, roleName);
        return result.Succeeded
            ? Result.Success()
            : Result.Failure(result.Errors.Select(e => new Error(e.Code, e.Description, ErrorType.Conflict)).ToList());
    }

    public async Task<Result<UserDTO>> AuthenticateAsync(string userName, string password)
    {
        var user = await _userManager.FindByNameAsync(userName);
        if (user is null)
            return Errors.User.NotFound(userName);

        var isValid = await _userManager.CheckPasswordAsync(user, password);
        return isValid
            ? user.ToDTO()
            : Errors.User.LoginFailure();
    }

    public async Task<Result> CreateUserAsync(UserDTO user, string password)
    {
        var result = await _userManager.CreateAsync(user.ToEntity(), password);
        return result.Succeeded
            ? Result.Success()
            : Result.Failure(result.Errors.Select(e => new Error(e.Code, e.Description, ErrorType.Conflict)).ToList());
    }

    public async Task<bool> ExistsAsync(Guid id)
    {
        return await _userManager.Users.AnyAsync(u => u.Id == id);
    }

    public async Task<Result<List<string>>> GetRolesByUserIdAsync(Guid userId)
    {
        var user = await _userManager.FindByIdAsync(userId.ToString());
        if (user is null)
            return Errors.User.NotFound(userId);

        var roles = await _userManager.GetRolesAsync(user);
        return roles.ToList();
    }

    public async Task<Result<UserDTO>> GetUserByEmailAsync(string email)
    {
        var result = await _userManager.FindByEmailAsync(email);
        return result is null
            ? Errors.User.NotFound(email)
            : result.ToDTO();
    }

    public async Task<Result<UserDTO>> GetUserByIdAsync(Guid userId)
    {
        var result = await _userManager.FindByIdAsync(userId.ToString());
        return result is null
            ? Errors.User.NotFound(userId)
            : result.ToDTO();
    }

    public async Task<Result<UserDTO>> GetUserByUserNameAsync(string userName)
    {
        var result = await _userManager.FindByNameAsync(userName);
        return result is null
            ? Errors.User.NotFound(userName)
            : result.ToDTO();
    }

    public async Task<Result> RemoveRoleFromUserAsync(Guid userId, string roleName)
    {
        var user = await _userManager.FindByIdAsync(userId.ToString());
        if (user is null)
            return Errors.User.NotFound(userId);

        var result = await _userManager.RemoveFromRoleAsync(user, roleName);
        return result.Succeeded
            ? Result.Success()
            : Result.Failure(result.Errors.Select(e => new Error(e.Code, e.Description, ErrorType.Conflict)).ToList());
    }
}
