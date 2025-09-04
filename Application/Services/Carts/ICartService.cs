using Application.Common.Results;
using Domain;

namespace Application.Services.Carts;

public interface ICartService
{
    Task<Result<CartItem>> GetCartItemByIdAsync(int id);
    Task<Result<IEnumerable<CartItem>>> GetCartByUserIdAsync(int userId);
    Task<Result> AddItemToCartAsync(int userId, int foodId, int quantity);
    Task<Result> RemoveItemFromCartAsync(int cartItemId);
    Task<Result> UpdateItemQuantityAsync(int cartItemId, int quantity);
    Task<Result> ClearCartAsync(int userId);
}
