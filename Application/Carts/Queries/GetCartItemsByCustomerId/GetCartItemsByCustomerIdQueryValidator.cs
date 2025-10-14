using Application.Common.Errors;
using Application.Common.Interfaces.Persistance.Repositories;
using Application.Common.Validations;
using FluentValidation;

namespace Application.Carts.Queries.GetCartItemsByCustomerId;

public class GetCartItemsByCustomerIdQueryValidator : AbstractValidator<GetCartItemsByCustomerIdQuery>
{
    public GetCartItemsByCustomerIdQueryValidator()
    {
        RuleFor(x => x.CustomerId)
            .NotEmpty().WithMessage("CustomerId is required.");
    }
}
