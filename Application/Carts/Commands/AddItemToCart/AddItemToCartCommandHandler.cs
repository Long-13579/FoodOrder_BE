using Application.Common.Errors;
using Application.Common.Interfaces.Persistance.Repositories;
using Application.Common.Results;
using MediatR;

namespace Application.Carts.Commands.AddItemToCart;

public class AddItemToCartCommandHandler : IRequestHandler<AddItemToCartCommand, Result>
{
    private readonly ICartRepository _cartRepository;
    private readonly IFoodRepository _foodRepository;

    public AddItemToCartCommandHandler(ICartRepository cartRepository, IFoodRepository foodRepository)
    {
        _cartRepository = cartRepository;
        _foodRepository = foodRepository;
    }

    public async Task<Result> Handle(AddItemToCartCommand request, CancellationToken cancellationToken)
    {
        var food = await _foodRepository.GetFoodByIdAsync(request.FoodId);
        if (food is null)
        {
            return Errors.Food.NotFound(request.FoodId);
        }

        await _cartRepository.AddCartItemAsync(request.UserId, food, request.Quantity);

        return Result.Success();
    }
}
