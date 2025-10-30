using Application.Common.Models;
using Application.Common.Requests;
using Application.Common.Results;

namespace Application.Foods.Queries.GetFoodsByCategory;

public record GetFoodsByCategoryQuery(
    int CategoryId
) : IQuery<Result<IEnumerable<FoodDTO>>>
{ }
