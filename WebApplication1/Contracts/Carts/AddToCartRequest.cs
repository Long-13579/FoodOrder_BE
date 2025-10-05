namespace WebApplication1.Contracts.Carts;

public class AddToCartRequest
{
    public Guid UserId { get; set; }
    public int FoodId { get; set; }
    public int Quantity { get; set; }
    public AddToCartRequest(Guid userId, int foodId, int quantity)
    {
        UserId = userId;
        FoodId = foodId;
        Quantity = quantity;
    }
}
