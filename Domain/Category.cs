namespace Domain;

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; } = String.Empty;
    public string Description { get; set; } = String.Empty;

    public ICollection<Food> Foods { get; set; } = new List<Food>();
}
