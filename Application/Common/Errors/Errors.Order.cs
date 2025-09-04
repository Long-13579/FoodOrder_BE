using Application.Common.Results;

namespace Application.Common.Errors;

public partial class Errors
{
    public static class Order
    {
        public static Error NotFound(int orderId) =>
            new(
                Code: "Order.NotFound",
                Description: $"Order with ID '{orderId}' was not found.",
                Type: ErrorType.NotFound
            );
        public static Error InvalidStatus(string status) =>
            new(
                Code: "Order.InvalidStatus",
                Description: $"The order status '{status}' is invalid.",
                Type: ErrorType.Validation
            );
        public static Error MissInformation() =>
            new(
                Code: "Order.MissInformation",
                Description: $"Order miss information",
                Type: ErrorType.Validation
            );
    }
}
