using Application.Common.Errors;
using Application.Common.Interfaces.Payment;
using Application.Common.Interfaces.Persistance.Repositories;
using Application.Common.Models;
using Application.Common.Results;
using Domain;
using MediatR;

namespace Application.Payments.Command.FinishCheckout;

internal class FinishCheckoutCommandHandler : IRequestHandler<FinishCheckoutCommand, Result>
{
    private readonly IOrderRepository _orderRepository;
    private readonly ICustomerRepository _customerRepository;
    private readonly IMomoPayment _momoPayment;

    public FinishCheckoutCommandHandler(IOrderRepository orderRepository, ICustomerRepository customerRepository, IMomoPayment momoPayment)
    {
        _orderRepository = orderRepository;
        _customerRepository = customerRepository;
        _momoPayment = momoPayment;
    }

    public async Task<Result> Handle(FinishCheckoutCommand request, CancellationToken cancellationToken)
    {
        var dist = _momoPayment.DecodeExtraData(request.ExtraData);

        if (!dist.ContainsKey("orderId"))
        {
            return Errors.Payment.ExtraDataMissingData("orderId");
        }

        var orderId = Guid.Parse(dist["orderId"]);
        var order = await _orderRepository.GetOrderByIdAsync(orderId);

        if (order == null)
        {
            return Errors.Order.NotFound(orderId);
        }

        order.Status = OrderStatus.Paid;
        await _orderRepository.UpdateOrderAsync(OrderDTO.ToDomain(order));

        return Result.Success();
    }
}
