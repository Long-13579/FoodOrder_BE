using Domain;
using ErrorOr;
using MediatR;

namespace Application.OrderServices.Commands.AddOrder;

public class AddOrderCommand : IRequest<ErrorOr<int>>
{
    public string UserId { get; set; } = string.Empty;
    public string CustomerName { get; set; } = string.Empty;
    public string CustomerEmail { get; set; } = string.Empty;
    public string CustomerPhone { get; set; } = string.Empty;
    public string CustomerAddress { get; set; } = string.Empty;
    public string Note { get; set; } = string.Empty;
    public List<OrderItemCommand> OrderItems { get; set; } = new List<OrderItemCommand>();
}

public class OrderItemCommand
{
    public int FoodId { get; set; }
    public int Quantity { get; set; }
    public string Note { get; set; } = string.Empty;
}
