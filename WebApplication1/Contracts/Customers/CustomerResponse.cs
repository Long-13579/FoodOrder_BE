using Domain;

namespace WebApplication1.Contracts.Customers;

public class CustomerResponse
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public DateOnly? DateOfBirth { get; set; }
    public string Address { get; set; } = string.Empty;

    public static CustomerResponse FromDomain(Customer customer)
    {
        return new CustomerResponse
        {
            Id = customer.Id,
            FirstName = customer.FirstName ?? string.Empty,
            LastName = customer.LastName ?? string.Empty,
            Email = customer.Email,
            PhoneNumber = customer.PhoneNumber,
            DateOfBirth = customer.DateOfBirth,
            Address = customer.Address ?? string.Empty
        };
    }
}
