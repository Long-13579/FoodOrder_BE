namespace Contract.Cart;

public class AddToCartRequest
{
    public int UserId { get; set; } 
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public AddToCartRequest(int userId, int productId, int quantity)
    {
        UserId = userId;
        ProductId = productId;
        Quantity = quantity;
    }
}
