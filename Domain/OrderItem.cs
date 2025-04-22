namespace Domain;

public class OrderItem
{
    public int Id { get; set; }
    public int OrderId { get; set; }
    public int FoodId { get; set; }
    public int Quantity { get; set; }
    public string Note { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public decimal Total => Quantity * Price;

    public Food Food { get; set; } = new Food();
}
