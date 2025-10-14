using Domain;

namespace Application.Common.Models;

public class OrderDTO
{
    public int Id { get; set; }
    public Guid CustomerId { get; set; }
    public string CustomerName { get; set; } = string.Empty;
    public string CustomerEmail { get; set; } = string.Empty;
    public string CustomerPhone { get; set; } = string.Empty;
    public string CustomerAddress { get; set; } = string.Empty;
    public string Note { get; set; } = string.Empty;

    public OrderStatus Status { get; set; }
    public DateTime CreatedAt { get; set; } 

    public List<OrderItemDTO> OrderItems { get; set; } = new();
}

public class OrderItemDTO
{
    public int Id { get; set; }
    public int OrderId { get; set; }
    public int FoodId { get; set; }
    public int Quantity { get; set; }
    public string Note { get; set; } = string.Empty;
    public decimal UnitPrice { get; set; }
    public Food Food { get; set; } = null!;
}
