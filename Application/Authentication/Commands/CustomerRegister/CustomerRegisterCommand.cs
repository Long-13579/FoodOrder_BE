using Application.Authentication.Common;
using Application.Common.Requests;
using Application.Common.Results;

namespace Application.Authentication.Commands.Register;

public record CustomerRegisterCommand(
    string UserName,
    string Email,
    string Password,
    string PhoneNumber
) : ICommand<Result<AuthenticationResult>>
{
    public string RoleName { get; } = "Customer";
}

