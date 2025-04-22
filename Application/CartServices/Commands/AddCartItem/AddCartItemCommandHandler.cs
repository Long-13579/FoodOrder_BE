using Application.Common.Interfaces;
using Application.Common.Errors;
using Domain;
using ErrorOr;
using MediatR;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Application.CartServices.Commands.AddCartItem;

public class AddCartItemCommandHandler : IRequestHandler<AddCartItemCommand, ErrorOr<Unit>>
{
    private readonly ICartRepository _cartRepository;
    private readonly IUserRepository _userRepository;
    private readonly IFoodRepository _foodRepository;

    public AddCartItemCommandHandler(ICartRepository cartRepository, IUserRepository userRepository, IFoodRepository foodRepository)
    {
        _cartRepository = cartRepository;
        _userRepository = userRepository;
        _foodRepository = foodRepository;
    }

    public async Task<ErrorOr<Unit>> Handle(AddCartItemCommand request, CancellationToken cancellationToken)
    {
        User? user = await _userRepository.GetUserByIdAsync(request.UserId);
        Food food = await _foodRepository.GetFoodByIdAsync(request.FoodId);

        if (user is null)
        {
            return Errors.User.NotFound(request.UserId);
        }

        if (food is null)
        {
            return Errors.Food.NotFound(request.FoodId);
        }

        await _cartRepository.AddCartItemAsync(request.UserId, food, request.Quantity);

        return Unit.Value;
    }
}
