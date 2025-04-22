using Application.Common.Interfaces;
using Application.Common.Errors;
using Domain;
using ErrorOr;
using MediatR;

namespace Application.CartServices.Commands.UpdateQuantity;

public class UpdateQuantityCommandHandler : IRequestHandler<UpdateQuantityCommand, ErrorOr<Unit>>
{
    private readonly ICartRepository _cartRepository;

    public UpdateQuantityCommandHandler(ICartRepository cartRepository)
    {
        _cartRepository = cartRepository;
    }

    public async Task<ErrorOr<Unit>> Handle(UpdateQuantityCommand request, CancellationToken cancellationToken)
    {
        CartItem? cartItem = await _cartRepository.GetCartItemByIdAsync(request.CartItemId);

        if (cartItem is null)
        {
            return Errors.CartItem.NotFound(request.CartItemId);
        }

        if (request.Quantity <= 0)
        {
            return Errors.CartItem.InvalidQuantity(request.Quantity);
        }

        await _cartRepository.UpdateQuantityAsync(request.CartItemId, request.Quantity);

        return Unit.Value;
    }
}
