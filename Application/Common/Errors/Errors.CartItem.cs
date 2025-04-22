using ErrorOr;

namespace Application.Common.Errors;

public static partial class Errors
{
    public static class CartItem
    {
        public static Error NotFound(int cartItemId) =>
            Error.NotFound(
                code: "CartItem.NotFound",
                description: $"Cart item with id {cartItemId} was not found.");

        public static Error InvalidQuantity(int quantity) =>
            Error.Validation(
                code: "CartItem.InvalidQuantity",
                description: $"Invalid quantity {quantity}. Quantity must be greater than 0.");
    }
}
