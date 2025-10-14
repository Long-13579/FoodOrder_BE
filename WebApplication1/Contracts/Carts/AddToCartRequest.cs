namespace WebApplication1.Contracts.Carts;

public class AddToCartRequest
{
    public int FoodId { get; set; }
    public int Quantity { get; set; }
    public AddToCartRequest(int foodId, int quantity)
    {
        FoodId = foodId;
        Quantity = quantity;
    }
}
