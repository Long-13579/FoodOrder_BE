using Application.Common.Models;
using Domain;

namespace Application.Common.Interfaces.Persistance.Repositories;

public interface ICartRepository : IRepository<int>
{
    Task<IEnumerable<CartItem>> GetCartByCustomerIdAsync(Guid customerId);
    Task<CartItem?> GetCartItemByIdAsync(int cartItemId);
    Task<IEnumerable<CartItem>> GetCartItemByIdsAsync(Guid customerId, IEnumerable<int> cartItemIds);
    Task ClearCartAsync(Guid customerId);
    Task AddCartItemAsync(Guid customerId, FoodDTO food, int quantity);
    Task UpdateQuantityAsync(int cartItemId, int quantity);
    Task DeleteCartItemAsync(Guid customerId, int cartItemId);
    Task DeleteCartItemsAsync(Guid customerId, IEnumerable<int> cartItemIds);
}