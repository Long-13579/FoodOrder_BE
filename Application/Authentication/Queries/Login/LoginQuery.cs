using Application.Authentication.Common;
using Application.Common.Requests;
using Application.Common.Results;

namespace Application.Authentication.Queries.Login;

public record LoginQuery(
    string Email,
    string Password
) : IQuery<Result<AuthenticationResult>>
{ }