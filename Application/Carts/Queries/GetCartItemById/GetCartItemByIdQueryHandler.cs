using Application.Common.Errors;
using Application.Common.Interfaces.Persistance.Repositories;
using Application.Common.Results;
using Domain;
using MediatR;

namespace Application.Carts.Queries.GetCartItemById;

public class GetCartItemByIdQueryHandler : IRequestHandler<GetCartItemByIdQuery, Result<CartItem>>
{
    private readonly ICartRepository _cartRepository;

    public GetCartItemByIdQueryHandler(ICartRepository cartRepository)
    {
        _cartRepository = cartRepository;
    }

    public async Task<Result<CartItem>> Handle(GetCartItemByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _cartRepository.GetCartItemByIdAsync(request.Id);
        return result is null
            ? Errors.CartItem.NotFound(request.Id)
            : result;
    }
}
