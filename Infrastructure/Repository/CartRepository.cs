using Application.Common.Interfaces;
using Domain;
using Infrastucture;

namespace Infrastructure.Repository;

public class CartRepository : ICartRepository
{
    private readonly DataContext _context;

    public CartRepository(DataContext dataContext)
    {
        _context = dataContext;
    }

    public async Task<CartItem?> GetCartItemByIdAsync(int cartItemId)
    {
        await Task.Delay(10);
        return _context.Cart.FirstOrDefault(x => x.CartItemId == cartItemId);
    }

    public async Task AddCartItemAsync(string userId, Food food, int quantity)
    {
        await Task.Delay(10);

        CartItem? cartItem = _context.Cart.FirstOrDefault(x => x.UserId == userId && x.FoodId == food.Id);

        if (cartItem is null)
        {
            _context.Cart.Add(new CartItem
            {
                CartItemId = _context.Cart.Count() + 1,
                UserId = userId,
                FoodId = food.Id,
                Quantity = quantity,
                UnitPrice = food.Price,
                User = _context.Users.FirstOrDefault(x => x.UserId == userId),
                Food = food
            });
        }
        else
        {
            cartItem.Quantity += quantity;
        }
    }

    public async Task ClearCartAsync(string userId)
    {
        await Task.Delay(10);

        _context.Cart.RemoveAll(x => x.UserId == userId);
    }

    public async Task DeleteCartItemAsync(int cartItemId)
    {
        await Task.Delay(10);

        _context.Cart.RemoveAll(x => x.CartItemId == cartItemId);
    }

    public async Task<List<CartItem>> GetCartByUserIdAsync(string userId)
    {
        await Task.Delay(10);

        return _context.Cart
            .Where(x => x.UserId == userId)
            .ToList();
    }

    public async Task UpdateQuantityAsync(int cartItemId, int quantity)
    {
        await Task.Delay(10);

        CartItem? cartItem = _context.Cart.FirstOrDefault(x => x.CartItemId == cartItemId);

        if (cartItem is not null)
        {
            cartItem.Quantity = quantity;
        }
    }
}
