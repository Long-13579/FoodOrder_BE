using Application.Common.Errors;
using Application.Common.Interfaces;
using Application.Common.Results;
using Domain;

namespace Application.Services.Orders;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IOrderDomainService _orderDomainService;

    public OrderService(IOrderRepository orderRepository, IUnitOfWork unitOfWork, IOrderDomainService orderDomainService)
    {
        _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        _orderDomainService = orderDomainService;
    }

    public async Task<Result> AddOrderAsync(Order order)
    {
        var validateResult = await _orderDomainService.ValidateOrderAsync(order);
        if (!validateResult.IsSuccess)
        {
            return validateResult.Error;
        }

        await _unitOfWork.BeginTransactionAsync();

        try
        {
            await _orderRepository.AddOrderAsync(order);

            await _unitOfWork.SaveChangesAsync();
            await _unitOfWork.CommitTransactionAsync();

            return Result.Success();
        }
        catch (Exception)
        {
            await _unitOfWork.RollbackTransactionAsync();
            throw;
        }
    }

    public async Task<Result> DeleteOrderAsync(int id)
    {
        var order = await _orderRepository.GetOrderByIdAsync(id);
        if (order is null)
            return Errors.Order.NotFound(id);

        await _unitOfWork.BeginTransactionAsync();

        try
        {
            await _orderRepository.DeleteOrderAsync(id);

            await _unitOfWork.SaveChangesAsync();
            await _unitOfWork.CommitTransactionAsync();

            return Result.Success();
        }
        catch (Exception)
        {
            await _unitOfWork.RollbackTransactionAsync();
            throw;
        }
    }

    public Task<Result<IEnumerable<Order>>> GetAllOrdersAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<Result<Order>> GetOrderByIdAsync(int id)
    {
        var result = await _orderRepository.GetOrderByIdAsync(id);
        return result is null
            ? Errors.Order.NotFound(id)
            : result;
    }

    public async Task<Result<IEnumerable<Order>>> GetOrdersByUserIdAsync(int userId)
    {
        var validateResult = await _orderDomainService.EnsureUserExistsAsync(userId);
        if (!validateResult.IsSuccess)
        {
            return validateResult.Error;
        }

        var result = await _orderRepository.GetOrdersByCustomerIdAsync(userId);
        return result is null
            ? new List<Order>()
            : ResultFactory.From(result);
    }

    public async Task<Result> UpdateOrderAsync(Order order)
    {
        var oldOrder = await _orderRepository.GetOrderByIdAsync(order.Id);
        if (oldOrder is null)
            return Errors.Order.NotFound(order.Id);

        await _unitOfWork.BeginTransactionAsync();

        try
        {
            await _orderRepository.UpdateOrderAsync(order);

            await _unitOfWork.SaveChangesAsync();
            await _unitOfWork.CommitTransactionAsync();

            return Result.Success();
        }
        catch (Exception)
        {
            await _unitOfWork.RollbackTransactionAsync();
            throw;
        }
    }
}
