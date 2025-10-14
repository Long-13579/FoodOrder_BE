using Application.Common.Interfaces.Persistance.Repositories;
using Application.Common.Models;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistance.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly AppDbContext _context;

    public OrderRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<int> AddOrderAsync(Order order)
    {
        await _context.Orders.AddAsync(order);
        await _context.SaveChangesAsync();

        return order.Id;
    }

    public Task DeleteOrderAsync(int orderId)
    {
        throw new NotImplementedException();
    }

    public Task<bool> ExistsAsync(int id)
    {
        return _context.Orders.AnyAsync(x => x.Id == id);
    }

    public Task<Order?> GetOrderByIdAsync(int orderId)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<OrderDTO>> GetOrdersByCustomerIdAsync(Guid customerId)
    {
        return await _context.Orders
            .Where(o => o.CustomerId == customerId)
            .Select(o => new OrderDTO
            {
                Id = o.Id,
                CustomerId = o.CustomerId,
                CustomerName = o.CustomerName,
                CustomerEmail = o.CustomerEmail,
                CustomerPhone = o.CustomerPhone,
                CustomerAddress = o.CustomerAddress,
                Note = o.Note,
                Status = o.Status,
                CreatedAt = o.CreatedAt,
                OrderItems = o.OrderItems.Select(oi => new OrderItemDTO
                {
                    Id = oi.Id,
                    OrderId = oi.OrderId,
                    FoodId = oi.FoodId,
                    Quantity = oi.Quantity,
                    Note = oi.Note,
                    UnitPrice = oi.UnitPrice,
                    Food = oi.Food
                }).ToList()
            })
            .ToListAsync();
    }

    public Task<IEnumerable<Order>> GetOrdersByStatusAsync(OrderStatus status)
    {
        throw new NotImplementedException();
    }

    public Task UpdateOrderAsync(Order order)
    {
        throw new NotImplementedException();
    }
}
