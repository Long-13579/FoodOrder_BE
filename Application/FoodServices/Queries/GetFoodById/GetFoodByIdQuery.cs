using Domain;
using ErrorOr;
using MediatR;

namespace Application.FoodServices.Queries.GetFoodById;

public class GetFoodByIdQuery : IRequest<ErrorOr<Food>>
{
    public int Id { get; }
    public GetFoodByIdQuery(int id)
    {
        Id = id;
    }
}
