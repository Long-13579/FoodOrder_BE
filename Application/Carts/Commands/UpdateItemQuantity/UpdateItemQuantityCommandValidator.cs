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
            .NotEmpty().WithMessage("CartItemId is required")
            .GreaterThan(0).WithMessage("CartItemId must be greater than 0.");
        RuleFor(x => x.Quantity)
            .NotEmpty().WithMessage("Quantity is required")
            .GreaterThan(0).WithMessage("Quantity must be greater than 0.");
        RuleFor(x => x.CustomerId)
            .NotEmpty().WithMessage("CustomerId is required");
    }
}
