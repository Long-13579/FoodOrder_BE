using Application.Common.Interfaces;
using Application.Common.Results;
using Domain;
using MediatR;

namespace Application.Carts.Queries.GetCartItemsByUserId;

public class GetCartItemsByUserIdQueryHandler : IRequestHandler<GetCartItemsByUserIdQuery, Result<IEnumerable<CartItem>>>
{
    private readonly ICartRepository _cartRepository;

    public GetCartItemsByUserIdQueryHandler(ICartRepository cartRepository)
    {
        _cartRepository = cartRepository;
    }

    public async Task<Result<IEnumerable<CartItem>>> Handle(GetCartItemsByUserIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _cartRepository.GetCartByUserIdAsync(request.UserId);
        return ResultFactory.From(result);
    }
}
