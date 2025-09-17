using Application.Common.Interfaces.Persistance.Repositories;
using Application.Common.Results;
using MediatR;

namespace Application.Carts.Commands.UpdateItemQuantity;

public class UpdateItemQuantityCommandHandler : IRequestHandler<UpdateItemQuantityCommand, Result>
{
    private readonly ICartRepository _cartRepository;

    public UpdateItemQuantityCommandHandler(ICartRepository cartRepository)
    {
        _cartRepository = cartRepository;
    }

    public async Task<Result> Handle(UpdateItemQuantityCommand request, CancellationToken cancellationToken)
    {
        await _cartRepository.UpdateQuantityAsync(request.CartItemId, request.Quantity);
        return Result.Success();
    }
}
