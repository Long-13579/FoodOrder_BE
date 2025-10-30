using FluentValidation;

namespace Application.Foods.Queries.GetFoodsByCategory;

public class GetFoodsByCategoryQueryValidator : AbstractValidator<GetFoodsByCategoryQuery>
{
    public GetFoodsByCategoryQueryValidator()
    {
        RuleFor(x => x.CategoryId)
            .NotEmpty().WithMessage("CategoryId is required.")
            .GreaterThan(0).WithMessage("CategoryId must greater than 0.");
    }
}
