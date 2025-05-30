namespace Contract.Cart;

public class UpdateCartItemRequest
{
    public int CartItemId { get; set; }
    public int Quantity { get; set; }

    public UpdateCartItemRequest(int cartItemId, int quantity)
    {
        CartItemId = cartItemId;
        Quantity = quantity;
    }
}