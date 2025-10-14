using System.Security.Claims;

namespace WebApplication1.Utils;

public static class ClaimsPrincipalExtensions
{
    public static Guid GetCustomerId(this ClaimsPrincipal user)
    {
        var customerIdClaim = user.Claims.FirstOrDefault(c => c.Type == "customer_id");
        if (customerIdClaim is null || !Guid.TryParse(customerIdClaim.Value, out var customerId))
        {
            throw new Exception("User ID claim is missing or invalid.");
        }
        return customerId;
    }
}
