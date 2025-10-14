using Application.Common.Results;

namespace Application.Common.Errors;

public static partial class Errors
{
    public static class Customer
    {
        public static Error NotFound(Guid customerId) => 
            new("Customer.NotFound",
                $"Customer with id {customerId} not found",
                ErrorType.NotFound);
    }
}
