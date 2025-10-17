using Application.Common.Models;
using Application.Common.Requests;
using Application.Common.Results;

namespace Application.Orders.Queries.GetOrdersByUserId;

public record GetOrdersByCustomerIdQuery(
    Guid CustomerId
) : IQuery<Result<IEnumerable<OrderDTO>>>
{ }
