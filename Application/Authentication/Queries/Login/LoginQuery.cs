using Application.Authentication.Common;
using Application.Common.Requests;
using Application.Common.Results;

namespace Application.Authentication.Queries.Login;

public record LoginQuery(
    string UserName,
    string Password
) : IQuery<Result<AuthenticationResult>>
{ }