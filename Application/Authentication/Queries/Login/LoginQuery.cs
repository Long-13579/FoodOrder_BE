using Application.Authentication.Common;
using Application.Common.Requests;
using Application.Common.Results;

namespace Application.Authentication.Queries.Login;

public class LoginQuery : IQuery<Result<AuthenticationResult>>
{
    public string UserName { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public LoginQuery(string userName, string password)
    {
        UserName = userName;
        Password = password;
    }
}
