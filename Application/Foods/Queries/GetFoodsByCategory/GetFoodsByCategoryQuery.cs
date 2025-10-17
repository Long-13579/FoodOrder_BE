using Application.Common.Requests;
using Application.Common.Results;
using Domain;

namespace Application.Foods.Queries.GetFoodsByCategory;

public record GetFoodsByCategoryQuery(
    FoodCategory Category
) : IQuery<Result<IEnumerable<Food>>>
{ }
