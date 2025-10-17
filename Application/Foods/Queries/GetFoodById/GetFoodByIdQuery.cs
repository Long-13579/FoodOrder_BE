using Application.Common.Requests;
using Application.Common.Results;
using Domain;

namespace Application.Foods.Queries.GetFoodById;

public record GetFoodByIdQuery(
    int Id
) : IQuery<Result<Food>>
{ }
