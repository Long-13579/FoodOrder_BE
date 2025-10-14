using Application.Common.Models;
using Domain;

namespace Application.Authentication.Common;

public class AuthenticationResult
{
    public UserDTO User { get; }
    public string Token { get; }
    public AuthenticationResult(UserDTO user, string token)
    {
        User = user;
        Token = token;
    }
}
