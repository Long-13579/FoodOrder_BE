using Domain;

namespace Application.Common.Interfaces.Persistance.Repositories;

public interface ICartRepository : IRepository<int>
{
    Task<IEnumerable<CartItem>> GetCartByUserIdAsync(Guid customerId);
    Task<CartItem?> GetCartItemByIdAsync(int cartItemId);
    Task<IEnumerable<CartItem>> GetCartItemByIdsAsync(Guid customerId, IEnumerable<int> cartItemIds);
    Task ClearCartAsync(Guid customerId);
    Task AddCartItemAsync(Guid customerId, Food food, int quantity);
    Task UpdateQuantityAsync(int cartItemId, int quantity);
    Task DeleteCartItemAsync(int cartItemId);
}