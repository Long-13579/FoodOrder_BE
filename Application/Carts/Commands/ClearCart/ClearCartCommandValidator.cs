using Application.Common.Interfaces.Persistance.Repositories;
using Application.Common.Validations;
using FluentValidation;

namespace Application.Carts.Commands.ClearCart;

public class ClearCartCommandValidator : AbstractValidator<ClearCartCommand>
{
    private readonly IUserRepository _userRepository;

    public ClearCartCommandValidator(IUserRepository userRepository)
    {
        _userRepository = userRepository;

        RuleFor(x => x.UserId)
            .MustExist(UserExists, "User");
    }

    private async Task<bool> UserExists(Guid userId, CancellationToken cancellationToken)
        => await _userRepository.ExistsAsync(userId);
}
