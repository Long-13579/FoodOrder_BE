using Application.Common.Models;
using Application.Common.Requests;
using Application.Common.Results;

namespace Application.Foods.Queries.GetFoodById;

public record GetFoodByIdQuery(
    int Id
) : IQuery<Result<FoodDTO>>
{ }
