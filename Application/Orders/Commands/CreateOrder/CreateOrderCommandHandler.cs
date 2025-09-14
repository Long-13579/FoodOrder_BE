using Application.Common.Interfaces;
using Application.Common.Results;
using Application.Orders.Factories;
using MediatR;

namespace Application.Orders.Commands.CreateOrder;

public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Result>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IOrderFactory _orderFactory;

    public CreateOrderCommandHandler(IOrderRepository orderRepository, IOrderFactory orderFactory)
    {
        _orderRepository = orderRepository;
        _orderFactory = orderFactory;
    }

    public async Task<Result> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var orderResult = await _orderFactory.CreateAsync(request);
        if (!orderResult.IsSuccess || orderResult.Value is null)
        {
            return orderResult.Error;
        }

        await _orderRepository.AddOrderAsync(orderResult.Value);
        return Result.Success();
    }
}
