using FluentValidation;

namespace Application.Carts.Queries.GetCartItemById;

public class GetCartItemByIdQueryValidator : AbstractValidator<GetCartItemByIdQuery>
{
    public GetCartItemByIdQueryValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("Id should greater than 0");
    }
}
