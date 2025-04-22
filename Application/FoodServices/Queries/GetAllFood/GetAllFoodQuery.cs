using Domain;
using ErrorOr;
using MediatR;

namespace Application.FoodServices.Queries.GetAllFood;

public class GetAllFoodQuery : IRequest<IEnumerable<Food>>
{
}
