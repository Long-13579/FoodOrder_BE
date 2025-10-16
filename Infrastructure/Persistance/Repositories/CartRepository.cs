using Application.Common.Interfaces.Persistance.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistance.Repositories;

public class CartRepository : ICartRepository
{
    private readonly AppDbContext _context;

    public CartRepository(AppDbContext dataContext)
    {
        _context = dataContext;
    }

    public async Task<CartItem?> GetCartItemByIdAsync(int cartItemId)
    {
        return await _context.CartItems.FirstOrDefaultAsync(x => x.Id == cartItemId);
    }

    public async Task AddCartItemAsync(Guid customerId, Food food, int quantity)
    {
        CartItem? cartItem = await _context.CartItems.FirstOrDefaultAsync(x => x.CustomerId == customerId && x.FoodId == food.Id);

        if (cartItem is null)
        {
            await _context.CartItems.AddAsync(new CartItem
            {
                CustomerId = customerId,
                FoodId = food.Id,
                Quantity = quantity,
                UnitPrice = food.Price,
            });
        }
        else
        {
            cartItem.Quantity += quantity;
        }

        await _context.SaveChangesAsync();
    }

    public async Task ClearCartAsync(Guid customerId)
    {
        await _context.CartItems
            .Where(x => x.CustomerId == customerId)
            .ExecuteDeleteAsync();
    }

    public async Task DeleteCartItemAsync(int cartItemId)
    {
        await _context.CartItems
            .Where(x => x.Id == cartItemId)
            .ExecuteDeleteAsync();
    }

    public async Task<IEnumerable<CartItem>> GetCartByCustomerIdAsync(Guid customerId)
    {
        return await _context.CartItems
            .Include(x => x.Food)
            .Where(x => x.CustomerId == customerId).ToListAsync();
    }

    public async Task<IEnumerable<CartItem>> GetCartItemByIdsAsync(Guid customerId, IEnumerable<int> cartItemIds)
    {
        return await _context.CartItems
            .Where(x => x.CustomerId == customerId && cartItemIds.Contains(x.Id))
            .ToListAsync();
    }

    public async Task UpdateQuantityAsync(int cartItemId, int quantity)
    {
        await _context.CartItems
            .Where(x => x.Id == cartItemId)
            .ExecuteUpdateAsync(setter => setter
                .SetProperty(c => c.Quantity, quantity));
    }

    public Task<bool> ExistsAsync(int id)
    {
        return _context.CartItems.AnyAsync(x => x.Id == id);
    }
}
