using Application.Common.Interfaces;
using Application.Common.Errors;
using Domain;
using ErrorOr;
using MediatR;

namespace Application.OrderServices.Queries.GetOrderByUserId;

public class GetOrderByUserIdQueryHandler : IRequestHandler<GetOrderByUserIdQuery, ErrorOr<List<Order>>>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IUserRepository _userRepository;
    public GetOrderByUserIdQueryHandler(IOrderRepository orderRepository, IUserRepository userRepository)
    {
        _orderRepository = orderRepository;
        _userRepository = userRepository;
    }
    public async Task<ErrorOr<List<Order>>> Handle(GetOrderByUserIdQuery request, CancellationToken cancellationToken)
    {
        User? user = await _userRepository.GetUserByIdAsync(request.UserId);

        if (user is null)
        {
            return Errors.User.NotFound(request.UserId);
        }

        IEnumerable<Order> orders = await _orderRepository.GetOrdersByCustomerIdAsync(request.UserId);
        return orders.ToList();
    }
}
