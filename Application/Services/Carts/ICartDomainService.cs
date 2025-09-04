using Application.Common.Results;
using Domain;

namespace Application.Services.Carts;

public interface ICartDomainService
{
    Task<Result<CartItem>> EnsureCartItemExistsAsync(int cartItemId);
    Task<Result<User>> EnsureUserExistsAsync(int userId);
    Task<Result<Food>> EnsureFoodExistsAsync(int foodId);
    Task<bool> ValidateQuantityAsync(int quantity);
}
