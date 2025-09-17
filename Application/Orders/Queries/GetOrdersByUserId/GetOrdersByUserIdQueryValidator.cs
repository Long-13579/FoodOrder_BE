using Application.Common.Interfaces.Persistance.Repositories;
using Application.Common.Validations;
using FluentValidation;

namespace Application.Orders.Queries.GetOrdersByUserId;

public class GetOrdersByUserIdQueryValidator : AbstractValidator<GetOrdersByUserIdQuery>
{
    private readonly IUserRepository _userRepository;

    public GetOrdersByUserIdQueryValidator(IUserRepository userRepository)
    {
        _userRepository = userRepository;

        RuleFor(x => x.UserId)
            .MustExist(UserExists, "User");
    }

    private async Task<bool> UserExists(int userId, CancellationToken cancellationToken)
        => await _userRepository.ExistsAsync(userId);
}
