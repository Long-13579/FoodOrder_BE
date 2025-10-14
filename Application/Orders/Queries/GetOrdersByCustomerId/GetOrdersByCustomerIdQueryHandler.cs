using Application.Common.Interfaces.Persistance.Repositories;
using Application.Common.Models;
using Application.Common.Results;
using Application.Orders.Queries.GetOrdersByUserId;
using Domain;
using MediatR;

namespace Application.Orders.Queries.GetOrdersByCustomerId;

public class GetOrdersByCustomerIdQueryHandler : IRequestHandler<GetOrdersByCustomerIdQuery, Result<IEnumerable<OrderDTO>>>
{
    private readonly IOrderRepository _orderRepository;

    public GetOrdersByCustomerIdQueryHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<Result<IEnumerable<OrderDTO>>> Handle(GetOrdersByCustomerIdQuery request, CancellationToken cancellationToken)
    {
        var orders = await _orderRepository.GetOrdersByCustomerIdAsync(request.CustomerId);
        return ResultFactory.From(orders);
    }
}
