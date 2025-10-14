using Application.Authentication.Common;
using Application.Common.Errors;
using Application.Common.Interfaces.Authentication;
using Application.Common.Interfaces.Persistance.Repositories;
using Application.Common.Models;
using Application.Common.Results;
using Domain;
using MediatR;

namespace Application.Authentication.Commands.Register;

public class CustomerRegisterCommandHandler : IRequestHandler<CustomerRegisterCommand, Result<AuthenticationResult>>
{
    private readonly IUserRepository _userRepository;
    private readonly ICustomerRepository _customerRepository;
    private readonly IRoleRepository _roleRepository;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public CustomerRegisterCommandHandler(IUserRepository userRepository,
                                  ICustomerRepository customerRepository,
                                  IJwtTokenGenerator jwtTokenGenerator,
                                  IRoleRepository roleRepository)
    {
        _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
        _jwtTokenGenerator = jwtTokenGenerator ?? throw new ArgumentNullException(nameof(jwtTokenGenerator));
        _roleRepository = roleRepository ?? throw new ArgumentNullException(nameof(roleRepository));
    }

    public async Task<Result<AuthenticationResult>> Handle(CustomerRegisterCommand request, CancellationToken cancellationToken)
    {
        var existingUserName = await _userRepository.GetUserByUserNameAsync(request.UserName);
        if (existingUserName.IsSuccess)
            return Errors.User.IdentifierAlreadyExists(request.UserName);

        var existingEmail = await _userRepository.GetUserByEmailAsync(request.Email);
        if (existingEmail.IsSuccess)
            return Errors.User.IdentifierAlreadyExists(request.Email);

        var roleResult = await _roleRepository.GetRoleByNameAsync(request.RoleName);
        if (!roleResult.IsSuccess)
            return roleResult.Errors;

        var role = roleResult.Value!;

        // Create User
        var customerId = Guid.NewGuid();
        var user = new UserDTO
        {
            Id = Guid.NewGuid(),
            UserName = request.UserName,
            Email = request.Email,
            PhoneNumber = request.PhoneNumber,
            CustomerId = customerId
        };

        var userCreateResult = await _userRepository.CreateUserAsync(user, request.Password);
        if (!userCreateResult.IsSuccess)
            throw new BusinessException(userCreateResult.ErrorsMessage);

        // Assign Role to User
        var assignResult = await _userRepository.AssignRoleToUserAsync(user.Id, role.Name);
        if (!assignResult.IsSuccess)
            throw new BusinessException(assignResult.ErrorsMessage);

        // Create Customer
        var customer = new Customer
        {
            Id = customerId,
            Email = request.Email,
            UserId = user.Id,
            PhoneNumber = request.PhoneNumber
        };

        var customerCreateResult = await _customerRepository.AddAsync(customer);
        if (!customerCreateResult.IsSuccess)
            throw new BusinessException(customerCreateResult.ErrorsMessage);

        var token = _jwtTokenGenerator.GenerateToken(user, new List<string> { role.Name });

        return new AuthenticationResult(user, token);
    }
}
