using Domain;

namespace Application.Common.Interfaces.Persistance.Repositories;

public interface ICartRepository : IRepository<int>
{
    Task<IEnumerable<CartItem>> GetCartByUserIdAsync(Guid userId);
    Task<CartItem?> GetCartItemByIdAsync(int cartItemId);
    Task<IEnumerable<CartItem>> GetCartItemByIdsAsync(Guid userId, IEnumerable<int> cartItemIds);
    Task ClearCartAsync(Guid userId);
    Task AddCartItemAsync(Guid userId, Food food, int quantity);
    Task UpdateQuantityAsync(int cartItemId, int quantity);
    Task DeleteCartItemAsync(int cartItemId);
}