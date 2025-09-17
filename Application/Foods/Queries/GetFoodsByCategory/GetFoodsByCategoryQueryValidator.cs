using FluentValidation;

namespace Application.Foods.Queries.GetFoodsByCategory;

public class GetFoodsByCategoryQueryValidator : AbstractValidator<GetFoodsByCategoryQuery>
{
    public GetFoodsByCategoryQueryValidator()
    {
        RuleFor(x => x.Category)
            .NotEmpty().WithMessage("Category is required.");
    }
}
