
using Application.Common.Interfaces;
using Application.Common.Results;
using Application.Common.Errors;
using Domain;

namespace Application.Services.Carts;

public class CartDomainService : ICartDomainService
{
    private readonly ICartRepository _cartRepository;
    private readonly IFoodRepository _foodRepository;
    private readonly IUserRepository _userRepository;

    public CartDomainService(ICartRepository cartRepository, IFoodRepository foodRepository, IUserRepository userRepository)
    {
        _cartRepository = cartRepository ?? throw new ArgumentNullException(nameof(cartRepository));
        _foodRepository = foodRepository ?? throw new ArgumentNullException(nameof(foodRepository));
        _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
    }

    public async Task<Result<CartItem>> EnsureCartItemExistsAsync(int cartItemId)
    {
        var cartItem = await _cartRepository.GetCartItemByIdAsync(cartItemId);
        return cartItem is null
            ? Errors.CartItem.NotFound(cartItemId)
            : cartItem;
    }

    public async Task<Result<Food>> EnsureFoodExistsAsync(int foodId)
    {
        var food = await _foodRepository.GetFoodByIdAsync(foodId);
        return food is null
            ? Errors.Food.NotFound(foodId)
            : food;
    }

    public async Task<Result<User>> EnsureUserExistsAsync(int userId)
    {
        var user = await _userRepository.GetUserByIdAsync(userId);
        return user is null
            ? Errors.User.NotFound(userId)
            : user;
    }

    public Task<bool> ValidateQuantityAsync(int quantity)
    {
        return Task.FromResult(quantity > 0);
    }
}
