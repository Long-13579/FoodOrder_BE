using Domain;

namespace Contract.Order;

public class AddOrderRequest
{
    public string UserId { get; set; } = string.Empty;
    public string CustomerName { get; set; } = string.Empty;
    public string CustomerEmail { get; set; } = string.Empty;
    public string CustomerPhone { get; set; } = string.Empty;
    public string CustomerAddress { get; set; } = string.Empty;
    public string Note { get; set; } = string.Empty;
    public List<OrderItemRequest> OrderItems { get; set; } = new List<OrderItemRequest>();
}

public class OrderItemRequest
{
    public int FoodId { get; set; }
    public int Quantity { get; set; }
    public string Note { get; set; } = string.Empty;
}
