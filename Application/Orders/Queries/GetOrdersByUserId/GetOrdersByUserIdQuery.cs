using Application.Common.Requests;
using Application.Common.Results;
using Domain;

namespace Application.Orders.Queries.GetOrdersByUserId;

public class GetOrdersByUserIdQuery : IQuery<Result<IEnumerable<Order>>>
{
    public int UserId { get; set; }

    public GetOrdersByUserIdQuery(int userId)
    {
        UserId = userId;
    }
}
