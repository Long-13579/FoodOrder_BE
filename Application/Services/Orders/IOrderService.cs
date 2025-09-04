using Application.Common.Results;
using Domain;

namespace Application.Services.Orders;

public interface IOrderService
{
    Task<Result<IEnumerable<Order>>> GetAllOrdersAsync();
    Task<Result<Order>> GetOrderByIdAsync(int id);
    Task<Result<IEnumerable<Order>>> GetOrdersByUserIdAsync(int userId);
    Task<Result> AddOrderAsync(Order order);
    Task<Result> UpdateOrderAsync(Order order);
    Task<Result> DeleteOrderAsync(int id);
}
