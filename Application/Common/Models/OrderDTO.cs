using Domain;

namespace Application.Common.Models;

public class OrderDTO
{
    public Guid Id { get; set; }
    public Guid CustomerId { get; set; }
    public string CustomerName { get; set; } = string.Empty;
    public string CustomerEmail { get; set; } = string.Empty;
    public string CustomerPhone { get; set; } = string.Empty;
    public string CustomerAddress { get; set; } = string.Empty;
    public string Note { get; set; } = string.Empty;

    public OrderStatus Status { get; set; }
    public DateTime CreatedAt { get; set; } 

    public List<OrderItemDTO> OrderItems { get; set; } = new();

    public static OrderDTO FromDomain(Order order)
    {
        return new OrderDTO
        {
            Id = order.Id,
            CustomerId = order.CustomerId,
            CustomerName = order.CustomerName,
            CustomerEmail = order.CustomerEmail,
            CustomerPhone = order.CustomerPhone,
            CustomerAddress = order.CustomerAddress,
            Note = order.Note,
            Status = order.Status,
            CreatedAt = order.CreatedAt,
            OrderItems = order.OrderItems.Select(OrderItemDTO.FromDomain).ToList()
        };
    }

    public static Order ToDomain(OrderDTO orderDTO)
    {
        return new Order
        {
            Id = orderDTO.Id,
            CustomerId = orderDTO.CustomerId,
            CustomerName = orderDTO.CustomerName,
            CustomerEmail = orderDTO.CustomerEmail,
            CustomerPhone = orderDTO.CustomerPhone,
            CustomerAddress = orderDTO.CustomerAddress,
            Note = orderDTO.Note,
            Status = orderDTO.Status,
            CreatedAt = orderDTO.CreatedAt,
            OrderItems = orderDTO.OrderItems.Select(OrderItemDTO.ToDomain).ToList()
        };
    }
}

public class OrderItemDTO
{
    public Guid Id { get; set; }
    public Guid OrderId { get; set; }
    public int FoodId { get; set; }
    public int Quantity { get; set; }
    public string Note { get; set; } = string.Empty;
    public decimal UnitPrice { get; set; }
    public Food Food { get; set; } = null!;

    public static OrderItemDTO FromDomain(OrderItem orderItem)
    {
        return new OrderItemDTO
        {
            Id = orderItem.Id,
            OrderId = orderItem.OrderId,
            FoodId = orderItem.FoodId,
            Quantity = orderItem.Quantity,
            Note = orderItem.Note,
            UnitPrice = orderItem.UnitPrice,
            Food = orderItem.Food
        };
    }

    public static OrderItem ToDomain(OrderItemDTO orderItemDTO)
    {
        return new OrderItem
        {
            Id = orderItemDTO.Id,
            OrderId = orderItemDTO.OrderId,
            FoodId = orderItemDTO.FoodId,
            Quantity = orderItemDTO.Quantity,
            Note = orderItemDTO.Note,
            UnitPrice = orderItemDTO.UnitPrice,
            Food = orderItemDTO.Food
        };
    }
}
