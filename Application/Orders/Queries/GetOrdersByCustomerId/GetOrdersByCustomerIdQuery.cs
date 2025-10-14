using Application.Common.Models;
using Application.Common.Requests;
using Application.Common.Results;

namespace Application.Orders.Queries.GetOrdersByUserId;

public class GetOrdersByCustomerIdQuery : IQuery<Result<IEnumerable<OrderDTO>>>
{
    public Guid CustomerId { get; set; }

    public GetOrdersByCustomerIdQuery(Guid customerId)
    {
        CustomerId = customerId;
    }
}
