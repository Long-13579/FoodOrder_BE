using FluentValidation;

namespace Application.Payments.Queries.CreateMomoPayment;

internal class CreateMomoPaymentQueryValidator : AbstractValidator<CreateMomoPaymentQuery>
{
    public CreateMomoPaymentQueryValidator()
    {
        RuleFor(x => x.OrderId)
            .NotEmpty().WithMessage("OrderId is required.");
        RuleFor(x => x.CustomerId)
            .NotEmpty().WithMessage("CustomerId is required.");
    }
}
