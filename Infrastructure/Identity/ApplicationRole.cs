using Application.Common.Models;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Identity;

public class ApplicationRole : IdentityRole<Guid>
{
    public string Description { get; set; } = string.Empty;

    public RoleDTO ToDTO()
    {
        return new RoleDTO
        {
            Id = this.Id,
            Name = this.Name ?? string.Empty,
            Description = this.Description
        };
    }
}
