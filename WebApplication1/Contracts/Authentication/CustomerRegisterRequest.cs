namespace WebApplication1.Contracts.Authentication;

public class CustomerRegisterRequest
{
    public string UserName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;

    public CustomerRegisterRequest(string userName,
                           string email,
                           string password,
                           string phoneNumber)
    {
        UserName = userName;
        Email = email;
        Password = password;
        PhoneNumber = phoneNumber;
    }
}
