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
        var user = await _userRepository.GetUserByUserNameAsync(request.UserName);
        if (user is null || user.Password != request.Password)
            return Errors.User.LoginFailure();

        var roles = await _userRepository.GetRolesByUserIdAsync(user.Id);

        var token = _jwtTokenGenerator.GenerateToken(user, roles);

        return new AuthenticationResult(user, token);
    }
}
