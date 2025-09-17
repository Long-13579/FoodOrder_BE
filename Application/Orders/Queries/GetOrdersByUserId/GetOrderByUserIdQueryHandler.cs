using Application.Common.Interfaces.Persistance.Repositories;
using Application.Common.Results;
using Domain;
using MediatR;

namespace Application.Orders.Queries.GetOrdersByUserId;

public class GetOrderByUserIdQueryHandler : IRequestHandler<GetOrdersByUserIdQuery, Result<IEnumerable<Order>>>
{
    private readonly IOrderRepository _orderRepository;

    public GetOrderByUserIdQueryHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<Result<IEnumerable<Order>>> Handle(GetOrdersByUserIdQuery request, CancellationToken cancellationToken)
    {
        var orders = await _orderRepository.GetOrdersByCustomerIdAsync(request.UserId);
        return ResultFactory.From(orders);
    }
}
