using Application.Common.Results;

namespace Application.Common.Errors;

public partial class Errors
{
    public static class Payment
    {
        public static Error CreationFailed() =>
            new(
                Code: "Payment.CreationFailed",
                Description: "Failed to create the payment.",
                Type: ErrorType.General
            );

        public static Error IsPaidOrder(Guid orderId) =>
            new(
                Code: "Payment.IsPaidOrder",
                Description: $"The order {orderId} has already been paid.",
                Type: ErrorType.General
            );

        public static Error ExtraDataMissingData(string key) =>
            new(
                Code: "Payment.ExtraDataMissingData",
                Description: $"The extra data is missing the required key: {key}.",
                Type: ErrorType.Validation
            );
    }
}
