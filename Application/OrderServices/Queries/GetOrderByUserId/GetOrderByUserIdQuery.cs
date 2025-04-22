using Domain;
using ErrorOr;
using MediatR;

namespace Application.OrderServices.Queries.GetOrderByUserId;

public class GetOrderByUserIdQuery : IRequest<ErrorOr<List<Order>>>
{
    public string UserId { get; set; } = string.Empty;

    public GetOrderByUserIdQuery(string userId)
    {
        UserId = userId;
    }
}
