namespace Domain;

public class Food
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public FoodCategory Category { get; set; }
    public string ImageUrl { get; set; } = string.Empty;
    public decimal Price { get; set; }
}
