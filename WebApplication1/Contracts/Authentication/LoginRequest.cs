namespace WebApplication1.Contracts.Authentication;

public class LoginRequest
{
    public string UserName { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;

    public LoginRequest(string userName, string password)
    {
        UserName = userName;
        Password = password;
    }
}
