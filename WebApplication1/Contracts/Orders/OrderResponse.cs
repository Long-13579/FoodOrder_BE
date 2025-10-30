using Application.Common.Models;

namespace WebApplication1.Contracts.Orders;

public class OrderResponse
{
    public Guid Id { get; set; }
    public List<OrderItemDTO> Items { get; set; } = new();
    public string CustomerName { get; set; } = string.Empty;
    public string CustomerEmail { get; set; } = string.Empty;
    public string CustomerPhone { get; set; } = string.Empty;
    public string CustomerAddress { get; set; } = string.Empty;
    public string Note { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public String Status { get; set; } = string.Empty;

    public static OrderResponse FromDomain(OrderDTO order)
    {
        return new OrderResponse
        {
            Id = order.Id,
            Items = order.OrderItems,
            CustomerName = order.CustomerName,
            CustomerEmail = order.CustomerEmail,
            CustomerPhone = order.CustomerPhone,
            CustomerAddress = order.CustomerAddress,
            Note = order.Note,
            CreatedAt = order.CreatedAt,
            Status = order.Status.ToString()
        };
    }

    public static IEnumerable<OrderResponse> FromDomain(IEnumerable<OrderDTO> order)
    {
        return order.Select(o => FromDomain(o));
    }
}
