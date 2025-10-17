using Application.Common.Interfaces.Persistance.Repositories;
using Application.Common.Validations;
using FluentValidation;

namespace Application.Carts.Commands.RemoveItemFromCart;

public class RemoveItemFromCartCommandValidator : AbstractValidator<RemoveItemFromCartCommand>
{
    public RemoveItemFromCartCommandValidator()
    {
        RuleFor(x => x.CartItemId)
            .NotEmpty().WithMessage("CartItemId is required.")
            .GreaterThan(0).WithMessage("CartItemId must be greater than zero.");
        RuleFor(x => x.CustomerId)
            .NotEmpty().WithMessage("CustomerId is required.");
    }
}
