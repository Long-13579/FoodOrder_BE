using FluentValidation;

namespace Application.Foods.Queries.GetFoodById;

public class GetFoodByIdQueryValidator : AbstractValidator<GetFoodByIdQuery>
{
    public GetFoodByIdQueryValidator()
    {
        RuleFor(x => x.Id)
            .NotNull()
            .GreaterThan(0).WithMessage("FoodId should greater than 0");
    }
}
