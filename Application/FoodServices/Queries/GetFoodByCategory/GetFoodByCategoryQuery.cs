using Domain;
using MediatR;

namespace Application.FoodServices.Queries.GetFoodByCategory;

public class GetFoodByCategoryQuery : IRequest<IEnumerable<Food>>
{
    public FoodCategory Category { get; } = FoodCategory.Other;

    public GetFoodByCategoryQuery(FoodCategory category)
    {
        Category = category;
    }
}
