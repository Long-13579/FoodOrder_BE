namespace Domain;

public class Customer
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string? FirstName { get; set; } = null!;
    public string? LastName { get; set; } = null!;
    public DateOnly? DateOfBirth { get; set; }
    public string PhoneNumber { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string? Address { get; set; } = null!;

    public List<Order> Orders { get; set; } = new();
    public List<CartItem> CartItems { get; set; } = new();
}
