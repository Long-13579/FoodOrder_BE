using Application.Common.Interfaces.Persistance.Repositories;
using Application.Common.Validations;
using FluentValidation;

namespace Application.Carts.Commands.RemoveItemFromCart;

public class RemoveItemFromCartCommandValidator : AbstractValidator<RemoveItemFromCartCommand>
{
    private readonly ICartRepository _cartRepository;

    public RemoveItemFromCartCommandValidator(ICartRepository cartRepository)
    {
        _cartRepository = cartRepository;

        RuleFor(x => x.CartItemId)
            .MustExist(CartItemExists, "Cart Item");
    }

    private async Task<bool> CartItemExists(int cartItemId, CancellationToken cancellationToken)
        => await _cartRepository.ExistsAsync(cartItemId);
}
