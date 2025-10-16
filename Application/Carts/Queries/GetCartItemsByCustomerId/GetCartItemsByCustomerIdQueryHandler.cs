using Application.Common.Interfaces.Persistance.Repositories;
using Application.Common.Results;
using Domain;
using MediatR;

namespace Application.Carts.Queries.GetCartItemsByCustomerId;

public class GetCartItemsByCustomerIdQueryHandler : IRequestHandler<GetCartItemsByCustomerIdQuery, Result<IEnumerable<CartItem>>>
{
    private readonly ICartRepository _cartRepository;

    public GetCartItemsByCustomerIdQueryHandler(ICartRepository cartRepository)
    {
        _cartRepository = cartRepository;
    }

    public async Task<Result<IEnumerable<CartItem>>> Handle(GetCartItemsByCustomerIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _cartRepository.GetCartByCustomerIdAsync(request.CustomerId);
        return ResultFactory.From(result);
    }
}
