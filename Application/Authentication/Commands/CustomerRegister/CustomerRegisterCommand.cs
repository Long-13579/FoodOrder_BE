using Application.Authentication.Common;
using Application.Common.Requests;
using Application.Common.Results;

namespace Application.Authentication.Commands.Register;

public class CustomerRegisterCommand : ICommand<Result<AuthenticationResult>>
{
    public string UserName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string RoleName { get; } = "Customer";
}
