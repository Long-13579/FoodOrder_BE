using Application.Common.Requests;
using Application.Common.Results;

namespace Application.Carts.Commands.RemoveItemFromCart;

public class RemoveItemFromCartCommand : ICommand<Result>
{
    public int CartItemId { get; set; }

    public RemoveItemFromCartCommand(int cartItemId)
    {
        CartItemId = cartItemId;
    }
}
