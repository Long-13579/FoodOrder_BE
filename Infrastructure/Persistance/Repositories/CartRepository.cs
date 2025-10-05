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

    public async Task AddCartItemAsync(Guid userId, Food food, int quantity)
    {
        CartItem? cartItem = await _context.CartItems.FirstOrDefaultAsync(x => x.UserId == userId && x.FoodId == food.Id);

        if (cartItem is null)
        {
            await _context.CartItems.AddAsync(new CartItem
            {
                UserId = userId,
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

    public async Task ClearCartAsync(Guid userId)
    {
        await _context.CartItems
            .Where(x => x.UserId == userId)
            .ExecuteDeleteAsync();
    }

    public async Task DeleteCartItemAsync(int cartItemId)
    {
        await _context.CartItems
            .Where(x => x.Id == cartItemId)
            .ExecuteDeleteAsync();
    }

    public async Task<IEnumerable<CartItem>> GetCartByUserIdAsync(Guid userId)
    {
        return await _context.CartItems
            .Include(x => x.Food)
            .Where(x => x.UserId == userId).ToListAsync();
    }

    public async Task<IEnumerable<CartItem>> GetCartItemByIdsAsync(Guid userId, IEnumerable<int> cartItemIds)
    {
        return await _context.CartItems
            .Where(x => x.UserId == userId && cartItemIds.Contains(x.Id))
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
