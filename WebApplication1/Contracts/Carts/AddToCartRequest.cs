namespace WebApplication1.Contracts.Carts;

public class AddToCartRequest
{
    public int UserId { get; set; }
    public int FoodId { get; set; }
    public int Quantity { get; set; }
    public AddToCartRequest(int userId, int foodId, int quantity)
    {
        UserId = userId;
        FoodId = foodId;
        Quantity = quantity;
    }
}
