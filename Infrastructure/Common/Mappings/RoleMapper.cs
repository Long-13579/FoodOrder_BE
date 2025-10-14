using Application.Common.Models;
using Infrastructure.Identity;

namespace Infrastructure.Common.Mappings;

public static class RoleMapper
{
    public static RoleDTO ToDTO(this ApplicationRole role)
    {
        return new RoleDTO
        {
            Id = role.Id,
            Name = role.Name ?? String.Empty,
            Description = role.Description
        };
    }

    public static ApplicationRole ToEntity(this RoleDTO roleDto)
    {
        return new ApplicationRole
        {
            Id = roleDto.Id,
            Name = roleDto.Name,
            Description = roleDto.Description
        };
    }
}
