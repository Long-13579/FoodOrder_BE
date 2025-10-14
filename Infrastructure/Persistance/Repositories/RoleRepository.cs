using Application.Common.Errors;
using Application.Common.Interfaces.Persistance.Repositories;
using Application.Common.Models;
using Application.Common.Results;
using Domain;
using Infrastructure.Common.Mappings;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistance.Repositories;

public class RoleRepository : IRoleRepository
{
    private readonly RoleManager<ApplicationRole> _roleManager;

    public RoleRepository(RoleManager<ApplicationRole> roleManager)
    {
        _roleManager = roleManager ?? throw new ArgumentNullException(nameof(roleManager));
    }

    public async Task<Result> CreateRoleAsync(RoleDTO role)
    {
        var result = await _roleManager.CreateAsync(role.ToEntity());
        return result.Succeeded
            ? Result.Success()
            : Result.Failure(result.Errors.Select(e => new Error(e.Code, e.Description, ErrorType.Conflict)).ToList());
    }

    public async Task<bool> ExistsAsync(Guid id)
    {
        return await _roleManager.Roles.AnyAsync(r => r.Id == id);
    }

    public async Task<Result<RoleDTO>> GetRoleByNameAsync(string roleName)
    {
        var role = await _roleManager.FindByNameAsync(roleName);
        return role is null
            ? Errors.Role.NotFound(roleName)
            : role.ToDTO();
    }
}
