using Application.Authentication.Common;

namespace WebApplication1.Contracts.Authentication;

public class AuthenticationResponse
{
    public Guid Id { get; set; }
    public string UserName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Token { get; set; } = string.Empty;

    public AuthenticationResponse(Guid id,
                                  string userName,
                                  string email,
                                  string token)
    {
        Id = id;
        UserName = userName;
        Email = email;
        Token = token;
    }

    public static AuthenticationResponse FromDomain(AuthenticationResult result)
    {
        return new AuthenticationResponse(result.User.Id,
                                          result.User.UserName,
                                          result.User.Email,
                                          result.Token);
    }
}
