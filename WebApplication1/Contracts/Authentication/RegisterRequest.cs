namespace WebApplication1.Contracts.Authentication;

public class RegisterRequest
{
    public string UserName { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;

    public RegisterRequest(string userName,
                           string firstName,
                           string lastName,
                           string email,
                           string phoneNumber,
                           string password,
                           string address)
    {
        UserName = userName;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        PhoneNumber = phoneNumber;
        Password = password;
        Address = address;
    }
}
