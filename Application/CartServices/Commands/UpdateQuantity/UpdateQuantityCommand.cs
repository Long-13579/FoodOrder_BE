using ErrorOr;
using MediatR;

namespace Application.CartServices.Commands.UpdateQuantity;

public class UpdateQuantityCommand : IRequest<ErrorOr<Unit>>
{
    public int CartItemId { get; set; }
    public int Quantity { get; set; }
    public UpdateQuantityCommand(int cartItemId, int quantity)
    {
        CartItemId = cartItemId;
        Quantity = quantity;
    }
}
