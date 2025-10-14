using Application.Common.Requests;
using Application.Common.Results;
using Domain;

namespace Application.Carts.Queries.GetCartItemsByCustomerId;

public class GetCartItemsByCustomerIdQuery : IQuery<Result<IEnumerable<CartItem>>>
{
    public Guid CustomerId { get; init; }

    public GetCartItemsByCustomerIdQuery(Guid customerId)
    {
        CustomerId = customerId;
    }
}
