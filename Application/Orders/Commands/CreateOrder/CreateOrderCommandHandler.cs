using Application.Common.Errors;
using Application.Common.Interfaces.Payment;
using Application.Common.Interfaces.Persistance.Repositories;
using Application.Common.Models;
using Application.Common.Results;
using Application.Orders.Factories;
using MediatR;

namespace Application.Orders.Commands.CreateOrder;

public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Result<string>>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IOrderFactory _orderFactory;
    private readonly ICartRepository _cartRepository;
    private readonly IMomoPayment _momoPayment;

    public CreateOrderCommandHandler(IOrderRepository orderRepository, IOrderFactory orderFactory, ICartRepository cartRepository, IMomoPayment momoPayment)
    {
        _orderRepository = orderRepository;
        _orderFactory = orderFactory;
        _cartRepository = cartRepository;
        _momoPayment = momoPayment;
    }

    public async Task<Result<string>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var orderResult = await _orderFactory.CreateAsync(request);
        if (!orderResult.IsSuccess)
        {
            return orderResult.Errors;
        }

        await _orderRepository.AddOrderAsync(orderResult.Value!);
        await _cartRepository.DeleteCartItemsAsync(request.CustomerId, request.CartItemIds);

        var paymentUrl = await _momoPayment.CreatePaymentUrl(OrderDTO.FromDomain(orderResult.Value!));
        if (string.IsNullOrEmpty(paymentUrl))
        {
            return Errors.Payment.CreationFailed();
        }

        return paymentUrl;
    }
}
