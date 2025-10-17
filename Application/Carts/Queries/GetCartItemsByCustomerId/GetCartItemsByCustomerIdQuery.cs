using Application.Common.Requests;
using Application.Common.Results;
using Domain;

namespace Application.Carts.Queries.GetCartItemsByCustomerId;

public record GetCartItemsByCustomerIdQuery(
    Guid CustomerId
) : IQuery<Result<IEnumerable<CartItem>>>
{ }
