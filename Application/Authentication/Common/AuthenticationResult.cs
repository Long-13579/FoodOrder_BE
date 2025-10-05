using Domain;

namespace Application.Authentication.Common;

public class AuthenticationResult
{
    public User User { get; }
    public string Token { get; }
    public AuthenticationResult(User user, string token)
    {
        User = user;
        Token = token;
    }
}
