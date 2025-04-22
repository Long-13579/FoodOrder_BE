using Domain;

namespace Application.Common.Interfaces;

public interface ICartRepository
{
    Task<List<CartItem>> GetCartByUserIdAsync(string userId);
    Task<CartItem?> GetCartItemByIdAsync(int cartItemId);
    Task ClearCartAsync(string userId);
    Task AddCartItemAsync(string userId, Food food, int quantity);
    Task UpdateQuantityAsync(int cartItemId, int quantity);
    Task DeleteCartItemAsync(int cartItemId);
}