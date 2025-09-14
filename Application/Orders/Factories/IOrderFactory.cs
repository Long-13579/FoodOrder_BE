using Application.Common.Results;
using Application.Orders.Commands.CreateOrder;
using Domain;

namespace Application.Orders.Factories;

public interface IOrderFactory
{
    Task<Result<Order>> CreateAsync(CreateOrderCommand command);
}
