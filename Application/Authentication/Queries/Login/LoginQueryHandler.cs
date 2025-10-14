using Application.Authentication.Common;
using Application.Common.Interfaces.Authentication;
using Application.Common.Interfaces.Persistance.Repositories;
using Application.Common.Results;
using Application.Common.Errors;
using MediatR;

namespace Application.Authentication.Queries.Login;

public class LoginQueryHandler : IRequestHandler<LoginQuery, Result<AuthenticationResult>>
{
    private readonly IUserRepository _userRepository;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public LoginQueryHandler(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator)
    {
        _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        _jwtTokenGenerator = jwtTokenGenerator ?? throw new ArgumentNullException(nameof(jwtTokenGenerator));
    }

    public async Task<Result<AuthenticationResult>> Handle(LoginQuery request, CancellationToken cancellationToken)
    {
        var authResult = await _userRepository.AuthenticateAsync(request.UserName, request.Password);
        if (!authResult.IsSuccess)
            return authResult.Errors;

        var user = authResult.Value!;

        var rolesResult = await _userRepository.GetRolesByUserIdAsync(user.Id);
        if (!rolesResult.IsSuccess)
            return rolesResult.Errors;

        var token = _jwtTokenGenerator.GenerateToken(user, rolesResult.Value!);

        return new AuthenticationResult(user, token);
    }
}
