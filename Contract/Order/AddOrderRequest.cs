namespace Contract.Order;

public class AddOrderRequest
{
    public int UserId { get; set; }
    public string CustomerName { get; set; } = string.Empty;
    public string CustomerEmail { get; set; } = string.Empty;
    public string CustomerPhone { get; set; } = string.Empty;
    public string CustomerAddress { get; set; } = string.Empty;
    public string Note { get; set; } = string.Empty;
    public List<OrderItemRequest> OrderItems { get; set; } = new List<OrderItemRequest>();

    public Domain.Order ToDomain()
    {
        return new Domain.Order
        {
            UserId = UserId,
            CustomerName = CustomerName,
            CustomerEmail = CustomerEmail,
            CustomerPhone = CustomerPhone,
            CustomerAddress = CustomerAddress,
            Note = Note,
            OrderItems = OrderItems.Select(item => new Domain.OrderItem
            {
                FoodId = item.FoodId,
                Quantity = item.Quantity,
                Note = item.Note
            }).ToList()
        };
    }
}

public class OrderItemRequest
{
    public int FoodId { get; set; }
    public int Quantity { get; set; }
    public string Note { get; set; } = string.Empty;
}
