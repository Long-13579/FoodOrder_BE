using Application.Common.Interfaces.Persistance.Repositories;
using Application.Common.Validations;
using FluentValidation;

namespace Application.Carts.Commands.UpdateItemQuantity;

public class UpdateItemQuantityCommandValidator : AbstractValidator<UpdateItemQuantityCommand>
{
    private readonly ICartRepository _cartRepository;

    public UpdateItemQuantityCommandValidator(ICartRepository cartRepository)
    {
        _cartRepository = cartRepository;

        RuleFor(x => x.CartItemId)
            .MustExist(CartExists, "Cart Item");
        RuleFor(x => x.Quantity)
            .NotEmpty().WithMessage("Quantity is required")
            .GreaterThan(0).WithMessage("Quantity must be greater than 0.");
    }

    private async Task<bool> CartExists(int cartItemId, CancellationToken cancellationToken)
        => await _cartRepository.ExistsAsync(cartItemId);
}
