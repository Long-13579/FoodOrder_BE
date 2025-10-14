namespace Domain;

public class CartItem
{
    public int Id { get; set; }
    public Guid CustomerId { get; set; }
    public int FoodId { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    
    public Food Food { get; set; } = null!;
    public Customer Customer { get; set; } = null!;
}