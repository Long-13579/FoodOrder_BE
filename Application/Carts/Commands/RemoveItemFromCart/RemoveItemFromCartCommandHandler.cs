using Application.Common.Errors;
using Application.Common.Interfaces.Persistance.Repositories;
using Application.Common.Results;
using MediatR;

namespace Application.Carts.Commands.RemoveItemFromCart;

public class RemoveItemFromCartCommandHandler : IRequestHandler<RemoveItemFromCartCommand, Result>
{
    private readonly ICartRepository _cartRepository;

    public RemoveItemFromCartCommandHandler(ICartRepository cartRepository)
    {
        _cartRepository = cartRepository;
    }

    public async Task<Result> Handle(RemoveItemFromCartCommand request, CancellationToken cancellationToken)
    {
        var cartItems = await _cartRepository.GetCartByCustomerIdAsync(request.CustomerId);
        if (cartItems is null || !cartItems.Any(ci => ci.Id == request.CartItemId))
        {
            return Errors.CartItem.NotFound(request.CartItemId);
        }
        await _cartRepository.DeleteCartItemAsync(request.CartItemId);
        return Result.Success();
    }
}
