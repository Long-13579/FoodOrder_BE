using Application.Common.Interfaces;
using Application.Common.Errors;
using Domain;
using ErrorOr;
using MediatR;

namespace Application.OrderServices.Commands.AddOrder;

public class AddOrderCommandHandler : IRequestHandler<AddOrderCommand, ErrorOr<int>>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IUserRepository _userRepository;
    private readonly IFoodRepository _foodRepository;

    public AddOrderCommandHandler(
        IOrderRepository orderRepository,
        IUserRepository userRepository,
        IFoodRepository foodRepository)
    {
        _orderRepository = orderRepository;
        _userRepository = userRepository;
        _foodRepository = foodRepository;
    }

    public async Task<ErrorOr<int>> Handle(AddOrderCommand request, CancellationToken cancellationToken)
    {
        User? user = await _userRepository.GetUserByIdAsync(request.UserId);

        if (user is null)
        {
            return Errors.User.NotFound(request.UserId);
        }

        List<Food> foods = await _foodRepository.GetAllFoodsAsync();

        foreach (var orderItem in request.OrderItems)
        {
            bool foodExists = foods.Any(f => f.Id == orderItem.FoodId);

            if (!foodExists)
            {
                return Errors.Food.NotFound(orderItem.FoodId);
            }
        }

        Order order = new Order()
        {
            UserId = request.UserId,
            CustomerName = request.CustomerName,
            CustomerEmail = request.CustomerEmail,
            CustomerPhone = request.CustomerPhone,
            CustomerAddress = request.CustomerAddress,
            Note = request.Note,
            OrderItems = request.OrderItems.Select(item => new OrderItem
            {
                FoodId = item.FoodId,
                Quantity = item.Quantity,
                Price = foods.First(x => x.Id == item.FoodId).Price,
                Note = item.Note
            }).ToList()
        };

        return await _orderRepository.AddOrderAsync(order);
    }
}
