using ErrorOr;
using MediatR;

namespace Application.CartServices.Commands.DeleteCartItem;

public class DeleteCartItemCommand : IRequest<Unit>
{
    public int CartItemId { get; set; }
    public DeleteCartItemCommand(int cartItemId)
    {
        CartItemId = cartItemId;
    }
}
