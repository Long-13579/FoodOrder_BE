using Application.Common.Requests;
using Application.Common.Results;
using Domain;

namespace Application.Foods.Queries.GetAllFoods;

public class GetAllFoodsQuery : IQuery<Result<IEnumerable<Food>>>
{
}
