using Application.Common.Results;

namespace Application.Common.Errors;

public static partial class Errors
{
    public static class CartItem
    {
        public static Error NotFound(int cartItemId) =>
            new (Code: "CartItem.NotFound",
                 Description: $"Cart item with id {cartItemId} was not found.",
                 Type: ErrorType.NotFound);

        public static Error InvalidQuantity(int quantity) =>
            new (Code: "CartItem.InvalidQuantity",
                 Description: $"Invalid quantity {quantity}. Quantity must be greater than 0.",
                 Type: ErrorType.Validation);
    }
}
