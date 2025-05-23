﻿using Domain;

namespace Application.Common.Interfaces;

public interface IOrderRepository
{
    Task<Order> GetOrderByIdAsync(int orderId);
    Task<IEnumerable<Order>> GetOrdersByCustomerIdAsync(string customerId);
    Task<IEnumerable<Order>> GetOrdersByStatusAsync(string status);
    Task<int> AddOrderAsync(Order order);
    Task UpdateOrderAsync(Order order);
    Task DeleteOrderAsync(int orderId);
}
