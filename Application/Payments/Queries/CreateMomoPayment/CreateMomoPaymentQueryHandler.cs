using Application.Common.Errors;
using Application.Common.Interfaces.Payment;
using Application.Common.Interfaces.Persistance.Repositories;
using Application.Common.Results;
using Domain;
using MediatR;

namespace Application.Payments.Queries.CreateMomoPayment;

internal class CreateMomoPaymentQueryHandler : IRequestHandler<CreateMomoPaymentQuery, Result<string>>
{
    private readonly IMomoPayment _momoPayment;
    private readonly IOrderRepository _orderRepository;

    public CreateMomoPaymentQueryHandler(IMomoPayment momoPayment, IOrderRepository orderRepository)
    {
        _momoPayment = momoPayment;
        _orderRepository = orderRepository;
    }

    public async Task<Result<string>> Handle(CreateMomoPaymentQuery request, CancellationToken cancellationToken)
    {
        var order = await _orderRepository.GetOrderByIdAsync(request.OrderId);
        if (order is null)
        {
            return Errors.Order.NotFound(request.OrderId);
        }

        if (order.CustomerId != request.CustomerId)
        {
            return Errors.Order.Authorization();
        }

        if (order.Status != OrderStatus.WaitingForPayment)
        {
            return Errors.Payment.IsPaidOrder(request.OrderId);
        }

        var paymentUrl = await _momoPayment.CreatePaymentUrl(order);
        if (string.IsNullOrEmpty(paymentUrl))
        {
            return Errors.Payment.CreationFailed();
        }

        return paymentUrl;
    }
}
