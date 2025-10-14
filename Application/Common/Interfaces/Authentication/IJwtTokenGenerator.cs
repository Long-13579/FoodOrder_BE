using Application.Common.Models;

namespace Application.Common.Interfaces.Authentication;

public interface IJwtTokenGenerator
{
    string GenerateToken(UserDTO user, IEnumerable<string> roles);
}
