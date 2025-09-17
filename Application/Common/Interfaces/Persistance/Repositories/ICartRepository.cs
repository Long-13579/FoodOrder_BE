using Domain;

namespace Application.Common.Interfaces.Persistance.Repositories;

public interface ICartRepository : IRepository<int>
{
    Task<IEnumerable<CartItem>> GetCartByUserIdAsync(int userId);
    Task<CartItem?> GetCartItemByIdAsync(int cartItemId);
    Task<IEnumerable<CartItem>> GetCartItemByIdsAsync(int userId, IEnumerable<int> cartItemIds);
    Task ClearCartAsync(int userId);
    Task AddCartItemAsync(int userId, Food food, int quantity);
    Task UpdateQuantityAsync(int cartItemId, int quantity);
    Task DeleteCartItemAsync(int cartItemId);
}