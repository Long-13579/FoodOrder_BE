using Application.Common.Requests;
using Application.Common.Results;
using Domain;

namespace Application.Foods.Queries.GetFoodsByCategory;

public class GetFoodsByCategoryQuery : IQuery<Result<IEnumerable<Food>>>
{
    public FoodCategory Category { get; set; }
    public GetFoodsByCategoryQuery(FoodCategory category)
    {
        Category = category;
    }
}
