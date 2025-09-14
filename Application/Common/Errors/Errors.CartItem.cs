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

        public static Error Empty() =>
            new(
                Code: "CartItem.Empty",
                Description: "The cart is empty.",
                Type: ErrorType.Validation);

        public static Error SomeItemsInvalid() =>
            new(
                Code: "CartItem.SomeItemsInvalid",
                Description: "Some cart items are invalid or not found for the current user.",
                Type: ErrorType.Validation);
    }
}
