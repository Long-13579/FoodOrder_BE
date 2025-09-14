namespace WebApplication1.Contracts.Orders;

public class CreateOrderRequest
{
    public List<int> CartItemIds { get; set; } = new List<int>();
    public int UserId { get; set; }
    public string CustomerName { get; set; } = string.Empty;
    public string CustomerEmail { get; set; } = string.Empty;
    public string CustomerPhone { get; set; } = string.Empty;
    public string CustomerAddress { get; set; } = string.Empty;
    public string? Note { get; set; }
}
