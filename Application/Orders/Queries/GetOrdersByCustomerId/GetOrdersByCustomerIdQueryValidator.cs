using Application.Common.Interfaces.Persistance.Repositories;
using Application.Common.Validations;
using FluentValidation;

namespace Application.Orders.Queries.GetOrdersByUserId;

public class GetOrdersByCustomerIdQueryValidator : AbstractValidator<GetOrdersByCustomerIdQuery>
{
    public GetOrdersByCustomerIdQueryValidator()
    {
        RuleFor(x => x.CustomerId)
            .NotEmpty().WithMessage("CustomerId is required.");
    }
}
