using Application.Common.Interfaces;
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
        await _cartRepository.DeleteCartItemAsync(request.CartItemId);
        return Result.Success();
    }
}
