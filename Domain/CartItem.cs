namespace Domain;

public class CartItem
{
    public int Id { get; set; }
    public Guid UserId { get; set; }
    public int FoodId { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    
    public User User { get; set; } = null!;
    public Food Food { get; set; } = null!;
}