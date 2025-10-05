namespace Domain;

public class User 
{
    public Guid Id { get; set; }
    public string UserName { get; set;} = string.Empty;
    public string FirstName { get; set;} = string.Empty;
    public string LastName { get; set;} = string.Empty;
    public string Email { get; set;} = string.Empty;
    public string PhoneNumber { get; set;} = string.Empty;
    public string Password { get; set;} = string.Empty;
    public string Address { get; set;} = string.Empty;

    public List<Order> Orders { get; set; } = new List<Order>();
    public List<CartItem> CartItems { get; set; } = new List<CartItem>();
    public List<UserRole> UserRoles { get; set; } = new List<UserRole>();
}