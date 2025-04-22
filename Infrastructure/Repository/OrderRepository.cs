using Application.Common.Interfaces;
using Domain;
using Infrastucture;

namespace Infrastructure.Repository;

public class OrderRepository : IOrderRepository
{
    private readonly DataContext _context;

    public OrderRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<int> AddOrderAsync(Order order)
    {
        await Task.CompletedTask; 

        order.Id = _context.Orders.Count() + 1; 
        _context.Orders.Add(order);

        return order.Id;
    }

    public Task DeleteOrderAsync(int orderId)
    {
        throw new NotImplementedException();
    }

    public Task<Order> GetOrderByIdAsync(int orderId)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Order>> GetOrdersByCustomerIdAsync(string customerId)
    {
        await Task.CompletedTask;

        return await Task.FromResult(_context.Orders.Where(o => o.UserId == customerId).ToList());
    }

    public Task<IEnumerable<Order>> GetOrdersByStatusAsync(string status)
    {
        throw new NotImplementedException();
    }

    public Task UpdateOrderAsync(Order order)
    {
        throw new NotImplementedException();
    }
}
