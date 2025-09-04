namespace Domain;

public class User 
{
    public int Id { get; set; }
    public string Name { get; set;} = string.Empty;

    public List<Order> Orders { get; set; } = new List<Order>();
    public List<CartItem> CartItems { get; set; } = new List<CartItem>();
}