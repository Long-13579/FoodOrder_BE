namespace Domain;

public class OrderItem
{
    public int Id { get; set; }
    public int OrderId { get; set; }
    public int FoodId { get; set; }
    public int Quantity { get; set; }
    public string Note { get; set; } = string.Empty;
    public decimal UnitPrice { get; set; }
    public decimal Total => Quantity * UnitPrice;

    public Food Food { get; set; } = null!;
    public Order Order { get; set; } = null!;
}
