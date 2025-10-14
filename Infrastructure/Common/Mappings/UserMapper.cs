using Application.Common.Models;
using Infrastructure.Identity;

namespace Infrastructure.Common.Mappings;

public static class UserMapper
{
    public static UserDTO ToDTO(this ApplicationUser user)
    {
        return new UserDTO
        {
            Id = user.Id,
            UserName = user.UserName ?? string.Empty,
            Email = user.Email ?? string.Empty,
            PhoneNumber = user.PhoneNumber ?? string.Empty,
            CustomerId = user.CustomerId
        };
    }

    public static ApplicationUser ToEntity(this UserDTO userDto)
    {
        return new ApplicationUser
        {
            Id = userDto.Id,
            UserName = userDto.UserName,
            Email = userDto.Email,
            PhoneNumber = userDto.PhoneNumber,
            CustomerId = userDto.CustomerId
        };
    }
}
