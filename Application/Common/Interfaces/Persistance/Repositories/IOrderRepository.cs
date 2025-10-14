using Application.Common.Models;
using Domain;

namespace Application.Common.Interfaces.Persistance.Repositories;

public interface IOrderRepository : IRepository<int>
{
    Task<Order?> GetOrderByIdAsync(int orderId);
    Task<IEnumerable<OrderDTO>> GetOrdersByCustomerIdAsync(Guid customerId);
    Task<IEnumerable<Order>> GetOrdersByStatusAsync(OrderStatus status);
    Task<int> AddOrderAsync(Order order);
    Task UpdateOrderAsync(Order order);
    Task DeleteOrderAsync(int orderId);
}
