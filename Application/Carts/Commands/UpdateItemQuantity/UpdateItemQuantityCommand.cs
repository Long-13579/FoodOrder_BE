using Application.Common.Requests;
using Application.Common.Results;

namespace Application.Carts.Commands.UpdateItemQuantity;

public class UpdateItemQuantityCommand : ICommand<Result>
{
    public int CartItemId { get; set; }
    public int Quantity { get; set; }

    public UpdateItemQuantityCommand(int cartItemId, int quantity)
    {
        CartItemId = cartItemId;
        Quantity = quantity;
    }
}
