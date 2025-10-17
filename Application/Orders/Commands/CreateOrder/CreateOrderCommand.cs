using Application.Common.Requests;
using Application.Common.Results;

namespace Application.Orders.Commands.CreateOrder;

public record CreateOrderCommand(
    List<int> CartItemIds,
    Guid CustomerId,
    string CustomerName,
    string CustomerEmail,
    string CustomerPhone,
    string CustomerAddress,
    string? Note = null
) : ICommand<Result>
{ }
