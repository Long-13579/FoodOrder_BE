using Application.Common.Interfaces;
using ErrorOr;
using MediatR;

namespace Application.CartServices.Commands.DeleteCartItem;

public class DeleteCartItemCommandHandler : IRequestHandler<DeleteCartItemCommand, Unit>
{
    private readonly ICartRepository _cartRepository;

    public DeleteCartItemCommandHandler(ICartRepository cartRepository)
    {
        _cartRepository = cartRepository;
    }

    public async Task<Unit> Handle(DeleteCartItemCommand request, CancellationToken cancellationToken)
    {
        await _cartRepository.DeleteCartItemAsync(request.CartItemId);

        return Unit.Value;
    }
}
