using Application.Authentication.Common;
using Application.Common.Errors;
using Application.Common.Interfaces.Authentication;
using Application.Common.Interfaces.Persistance.Repositories;
using Application.Common.Results;
using Domain;
using MediatR;

namespace Application.Authentication.Commands.Register;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, Result<AuthenticationResult>>
{
    private readonly IUserRepository _userRepository;
    private readonly IRoleRepository _roleRepository;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public RegisterCommandHandler(IUserRepository userRepository,
                                  IJwtTokenGenerator jwtTokenGenerator,
                                  IRoleRepository roleRepository)
    {
        _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        _jwtTokenGenerator = jwtTokenGenerator ?? throw new ArgumentNullException(nameof(jwtTokenGenerator));
        _roleRepository = roleRepository ?? throw new ArgumentNullException(nameof(roleRepository));
    }

    public async Task<Result<AuthenticationResult>> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        var role = await _roleRepository.GetRoleByNameAsync(request.RoleName);
        if (role is null)
            return Errors.Role.NotFound(request.RoleName);

        var user = new User
        {
            Id = Guid.NewGuid(),
            UserName = request.UserName,
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            PhoneNumber = request.PhoneNumber,
            Password = request.Password,
            Address = request.Address
        };

        await _userRepository.AddUserAsync(user);
        await _userRepository.AssignRoleToUserAsync(user.Id, role.Id);

        var token = _jwtTokenGenerator.GenerateToken(user, [role]);

        return new AuthenticationResult(user, token);
    }
}
