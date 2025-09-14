using Application.Common.Requests;
using Application.Common.Results;

namespace Application.Orders.Commands.CreateOrder;

public class CreateOrderCommand : ICommand<Result>
{
    public List<int> CartItemIds { get; set; } = new List<int>();
    public int UserId { get; set; }
    public string CustomerName { get; set; } = string.Empty;
    public string CustomerEmail { get; set; } = string.Empty;
    public string CustomerPhone { get; set; } = string.Empty;
    public string CustomerAddress { get; set; } = string.Empty;
    public string? Note { get; set; }

    public CreateOrderCommand(List<int> cartItemIds,
                              int userId,
                              string customerName,
                              string customerEmail,
                              string customerPhone,
                              string customerAddress,
                              string? note = null)
    {
        CartItemIds = cartItemIds;
        UserId = userId;
        CustomerName = customerName;
        CustomerEmail = customerEmail;
        CustomerPhone = customerPhone;
        CustomerAddress = customerAddress;
        Note = note;
    }
}
