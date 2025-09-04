using Domain;

namespace Application.Common.Interfaces;

public interface ICartRepository
{
    Task<IEnumerable<CartItem>> GetCartByUserIdAsync(int userId);
    Task<CartItem?> GetCartItemByIdAsync(int cartItemId);
    Task ClearCartAsync(int userId);
    Task AddCartItemAsync(int userId, Food food, int quantity);
    Task UpdateQuantityAsync(int cartItemId, int quantity);
    Task DeleteCartItemAsync(int cartItemId);
}