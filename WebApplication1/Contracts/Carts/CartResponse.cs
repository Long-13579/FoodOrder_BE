using Domain;

namespace WebApplication1.Contracts.Carts;

public class CartResponse
{
    public int Id { get; set; }
    public int Quantity { get; set; }
    public Food Food { get; set; } = null!;

    public static CartResponse FromDomain(CartItem cartItem)
    {
        return new CartResponse
        {
            Id = cartItem.Id,
            Quantity = cartItem.Quantity,
            Food = cartItem.Food
        };
    }

    public static List<CartResponse> FromDomain(List<CartItem> cartItems)
    {
        return cartItems.Select(item => FromDomain(item)).ToList();
    }
}
