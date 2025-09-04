namespace Domain;

public class Order
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string CustomerName { get; set; } = string.Empty;
    public string CustomerEmail { get; set; } = string.Empty;
    public string CustomerPhone { get; set; } = string.Empty;
    public string CustomerAddress { get; set; } = string.Empty;
    public string Note { get; set; } = string.Empty;

    public OrderStatus Status { get; set; } = OrderStatus.WaitingForPayment;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public List<OrderItem> OrderItems { get; set; } = null!;
    public User User { get; set; } = null!;

    public decimal Total => OrderItems.Sum(item => item.Total);
}
