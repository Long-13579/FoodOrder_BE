using Domain;

namespace Contract.Cart;

public class CartItemResponse
{
    public int Id { get; set; }
    public Food Food { get; set; } = null!;
    public int Quantity { get; set; }

    public CartItemResponse() { }

    public CartItemResponse(CartItem cartItem)
    {
        Id = cartItem.CartItemId;
        Food = cartItem.Food;
        Quantity = cartItem.Quantity;
    }

    public static CartItemResponse FromDomain(CartItem cartItem)
    {
        return new CartItemResponse(cartItem);
    }

    public static List<CartItemResponse> FromDomain(List<CartItem> cartItems)
    {
        return cartItems.Select(item => new CartItemResponse(item)).ToList();
    }
}