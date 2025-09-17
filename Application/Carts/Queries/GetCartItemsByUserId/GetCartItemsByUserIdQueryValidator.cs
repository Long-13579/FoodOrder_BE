using Application.Common.Errors;
using Application.Common.Interfaces.Persistance.Repositories;
using Application.Common.Validations;
using FluentValidation;

namespace Application.Carts.Queries.GetCartItemsByUserId;

public class GetCartItemsByUserIdQueryValidator : AbstractValidator<GetCartItemsByUserIdQuery>
{
    private readonly IUserRepository _userRepository;
    public GetCartItemsByUserIdQueryValidator(IUserRepository userRepository)
    {
        _userRepository = userRepository;

        RuleFor(x => x.UserId)
            .MustExist(UserExistsAsync, "User");
    }

    private async Task<bool> UserExistsAsync(int userId, CancellationToken cancellationToken) 
        => await _userRepository.ExistsAsync(userId);
}
