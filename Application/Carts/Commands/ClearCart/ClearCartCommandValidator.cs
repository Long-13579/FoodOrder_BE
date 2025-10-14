using Application.Common.Interfaces.Persistance.Repositories;
using Application.Common.Validations;
using FluentValidation;

namespace Application.Carts.Commands.ClearCart;

public class ClearCartCommandValidator : AbstractValidator<ClearCartCommand>
{
    public ClearCartCommandValidator()
    {
        RuleFor(x => x.CustomerId)
            .NotEmpty().WithMessage("CustomerId is required.");
    }
}
