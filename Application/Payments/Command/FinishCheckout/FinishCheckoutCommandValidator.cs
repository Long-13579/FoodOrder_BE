using FluentValidation;

namespace Application.Payments.Command.FinishCheckout;

internal class FinishCheckoutCommandValidator : AbstractValidator<FinishCheckoutCommand>
{
    public FinishCheckoutCommandValidator()
    {
        RuleFor(x => x.ExtraData)
            .NotEmpty().WithMessage("Extra data must not be empty.")
            .MaximumLength(500).WithMessage("Extra data must not exceed 500 characters.");
    }
}
