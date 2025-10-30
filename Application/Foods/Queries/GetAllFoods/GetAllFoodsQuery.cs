using Application.Common.Models;
using Application.Common.Requests;
using Application.Common.Results;

namespace Application.Foods.Queries.GetAllFoods;

public record GetAllFoodsQuery : IQuery<Result<IEnumerable<FoodDTO>>>
{
}
