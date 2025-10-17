using Application.Common.Requests;
using Application.Common.Results;
using Domain;

namespace Application.Foods.Queries.GetAllFoods;

public record GetAllFoodsQuery : IQuery<Result<IEnumerable<Food>>>
{
}
