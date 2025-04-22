namespace Domain;

public class CartItem
{
    public int CartItemId { get; set; }
    public string UserId { get; set; } = string.Empty;
    public int FoodId { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    
    public User User { get; set; } = null!;
    public Food Food { get; set; } = null!;
}