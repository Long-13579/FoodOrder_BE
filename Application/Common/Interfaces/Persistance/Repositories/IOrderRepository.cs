using Application.Common.Models;
using Domain;

namespace Application.Common.Interfaces.Persistance.Repositories;

public interface IOrderRepository : IRepository<Guid>
{
    Task<OrderDTO?> GetOrderByIdAsync(Guid orderId);
    Task<IEnumerable<OrderDTO>> GetOrdersByCustomerIdAsync(Guid customerId);
    Task<IEnumerable<OrderDTO>> GetOrdersByStatusAsync(OrderStatus status);
    Task AddOrderAsync(Order order);
    Task UpdateOrderAsync(Order order);
    Task DeleteOrderAsync(Guid orderId);
}
