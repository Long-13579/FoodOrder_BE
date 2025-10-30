using Domain;
using Domain.Constants;
using Infrastructure.Identity;

namespace Infrastructure.Persistance.Initializer;

public static class InitialData
{
    private static string imageUrl = "foods/foodImage.png";
    public static List<ApplicationRole> GenerateRoles()
    {
        var roles = new List<ApplicationRole>
        {
            new ApplicationRole { Name = RoleNames.Customer, Description = "Standard customer with limited access." },
            new ApplicationRole { Name = RoleNames.Admin, Description = "Administrator with full access." }
        };
        return roles;
    }

    public static Customer GenerateCustomer(Guid userId)
    {
        return new Customer
        {
            UserId = userId,
            FirstName = "John",
            LastName = "Doe",
            DateOfBirth = DateOnly.FromDateTime(DateTime.UtcNow),
            PhoneNumber = "0123456789",
            Email = "customer@gmail.com",
            Address = "123 Main St, City, Country"
        };
    }

    public static List<Category> GenerateCategories()
    {
        var categories = new List<Category>
        {
            new Category { Name = "Pho", Description = "Traditional Vietnamese noodle soup." },
            new Category { Name = "Banh Mi", Description = "Vietnamese sandwich with various fillings." },
            new Category { Name = "Noodle", Description = "Variety of Vietnamese noodle dishes." },
            new Category { Name = "Water", Description = "Beverages including teas and juices." },
            new Category { Name = "Other", Description = "Miscellaneous items." }
        };
        return categories;
    }

    public static List<Food> GenerateMenu()
    {
        var foods = new List<Food>();
        foods.AddRange(PhoMenu());
        foods.AddRange(BanhMiMenu());
        foods.AddRange(NoodleMenu());
        foods.AddRange(WaterMenu());
        foods.AddRange(OtherMenu());
        return foods;
    }

    private static List<Food> PhoMenu() => [
    new Food
        {
            Name = "Phở Bò Tái",
            Description = "Beef noodle soup with rare steak.",
            CategoryId = 1,
            Price = 45000,
            ImageUrl = imageUrl
        },
        new Food
        {
            Name = "Phở Bò Chín",
            Description = "Beef noodle soup with well-done brisket.",
            CategoryId = 1,
            Price = 45000,
            ImageUrl = imageUrl
        },
        new Food
        {
            Name = "Phở Gà",
            Description = "Chicken noodle soup with tender slices of chicken.",
            CategoryId = 1,
            Price = 40000,
            ImageUrl = imageUrl
        },
        new Food
        {
            Name = "Phở Tái Gân",
            Description = "Beef noodle soup with rare steak and tendon.",
            CategoryId = 1,
            Price = 50000,
            ImageUrl = imageUrl
        },
        new Food
        {
            Name = "Phở Tái Nạm",
            Description = "Beef noodle soup with rare steak and flank.",
            CategoryId = 1,
            Price = 50000,
            ImageUrl = imageUrl
        },
        new Food
        {
            Name = "Phở Bò Viên",
            Description = "Beef noodle soup with beef meatballs.",
            CategoryId = 1,
            Price = 45000,
            ImageUrl = imageUrl
        },
        new Food
        {
            Name = "Phở Sốt Vang",
            Description = "Pho with red wine stewed beef.",
            CategoryId = 1,
            Price = 55000,
            ImageUrl = imageUrl
        },
        new Food
        {
            Name = "Phở Gà Xé Phay",
            Description = "Pho with shredded chicken and herbs.",
            CategoryId = 1,
            Price = 40000,
            ImageUrl = imageUrl
        },
        new Food
        {
            Name = "Phở Bò Tái Lăn",
            Description = "Pho with stir-fried rare beef slices.",
            CategoryId = 1,
            Price = 50000,
            ImageUrl = imageUrl
        },
        new Food
        {
            Name = "Phở Chay",
            Description = "Vegetarian pho with tofu and mushrooms.",
            CategoryId = 1,
            Price = 38000,
            ImageUrl = imageUrl
        }
];

    private static List<Food> BanhMiMenu() => [
        new Food
        {
            Name = "Bánh Mì Thịt Nướng",
            Description = "Grilled pork sandwich with pickled vegetables.",
            CategoryId = 2,
            Price = 30000,
            ImageUrl = imageUrl
        },
        new Food
        {
            Name = "Bánh Mì Chả Lụa",
            Description = "Vietnamese pork sausage sandwich with cilantro and cucumber.",
            CategoryId = 2,
            Price = 25000,
            ImageUrl = imageUrl
        },
        new Food
        {
            Name = "Bánh Mì Pate",
            Description = "Pate and butter sandwich with herbs and fresh veggies.",
            CategoryId = 2,
            Price = 25000,
            ImageUrl = imageUrl
        },
        new Food
        {
            Name = "Bánh Mì Đặc Biệt",
            Description = "A combo sandwich with grilled pork, pate, and various meats.",
            CategoryId = 2,
            Price = 35000,
            ImageUrl = imageUrl
        },
        new Food
        {
            Name = "Bánh Mì Gà",
            Description = "Chicken sandwich with vegetables and herbs.",
            CategoryId = 2,
            Price = 28000,
            ImageUrl = imageUrl
        },
        new Food
        {
            Name = "Bánh Mì Bò",
            Description = "Beef sandwich with fresh cilantro and chili.",
            CategoryId = 2,
            Price = 30000,
            ImageUrl = imageUrl
        },
        new Food
        {
            Name = "Bánh Mì Trứng",
            Description = "Egg sandwich with mayo and fresh vegetables.",
            CategoryId = 2,
            Price = 22000,
            ImageUrl = imageUrl
        },
        new Food
        {
            Name = "Bánh Mì Xíu Mại",
            Description = "Pork meatball sandwich with pickled veggies and mayo.",
            CategoryId = 2,
            Price = 28000,
            ImageUrl = imageUrl
        },
        new Food
        {
            Name = "Bánh Mì Chay",
            Description = "Vegetarian sandwich with tofu, mushrooms, and herbs.",
            CategoryId = 2,
            Price = 25000,
            ImageUrl = imageUrl
        },
        new Food
        {
            Name = "Bánh Mì Tôm",
            Description = "Shrimp sandwich with mayonnaise and crunchy veggies.",
            CategoryId = 2,
            Price = 32000,
            ImageUrl = imageUrl
        }
    ];

    private static List<Food> NoodleMenu() => [
        new Food
        {
            Name = "Bún Chả",
            Description = "Grilled pork served with vermicelli noodles and dipping sauce.",
            CategoryId = 3,
            Price = 40000,
            ImageUrl = imageUrl
        },
        new Food
        {
            Name = "Bún Bò Huế",
            Description = "Spicy beef noodle soup from Huế with lemongrass and chili.",
            CategoryId = 3,
            Price = 45000,
            ImageUrl = imageUrl
        },
        new Food
        {
            Name = "Bún Thịt Nướng",
            Description = "Grilled pork on vermicelli with herbs and peanuts.",
            CategoryId = 3,
            Price = 40000,
            ImageUrl = imageUrl
        },
        new Food
        {
            Name = "Bún Mắm",
            Description = "Fermented fish broth noodle soup with seafood and pork.",
            CategoryId = 3,
            Price = 50000,
            ImageUrl = imageUrl
        },
        new Food
        {
            Name = "Bún Riêu",
            Description = "Crab and tomato soup with vermicelli noodles.",
            CategoryId = 3,
            Price = 42000,
            ImageUrl = imageUrl
        },
        new Food
        {
            Name = "Bún Gà Nướng",
            Description = "Grilled chicken with vermicelli and garlic fish sauce.",
            CategoryId = 3,
            Price = 38000,
            ImageUrl = imageUrl
        },
        new Food
        {
            Name = "Mì Quảng",
            Description = "Central Vietnamese turmeric noodles with shrimp and pork.",
            CategoryId = 3,
            Price = 45000,
            ImageUrl = imageUrl
        },
        new Food
        {
            Name = "Bún Nem Nướng",
            Description = "Grilled spring rolls with vermicelli and sweet dipping sauce.",
            CategoryId = 3,
            Price = 40000,
            ImageUrl = imageUrl
        },
        new Food
        {
            Name = "Hủ Tiếu Nam Vang",
            Description = "Phnom Penh-style noodle soup with pork and shrimp.",
            CategoryId = 3,
            Price = 48000,
            ImageUrl = imageUrl
        },
        new Food
        {
            Name = "Hủ Tiếu Xào",
            Description = "Stir-fried rice noodles with beef and vegetables.",
            CategoryId = 3,
            Price = 42000,
            ImageUrl = imageUrl
        }
    ];

    private static List<Food> WaterMenu() => [
        new Food
        {
            Name = "Peach Tea",
            Description = "Refreshing peach tea with real peach slices",
            CategoryId = 4,
            Price = 10000,
            ImageUrl = imageUrl
        },
        new Food
        {
            Name = "Sugarcane Juice",
            Description = "Freshly pressed sugarcane juice, served cold",
            CategoryId = 4,
            Price = 12000,
            ImageUrl = imageUrl
        },
        new Food
        {
            Name = "Soy Milk",
            Description = "Nutritious soy milk, served hot or cold",
            CategoryId = 4,
            Price = 15000,
            ImageUrl = imageUrl
        },
        new Food
        {
            Name = "Vietnamese Iced Coffee",
            Description = "Traditional Vietnamese drip coffee with condensed milk",
            CategoryId = 4,
            Price = 10000,
            ImageUrl = imageUrl
        },
        new Food
        {
            Name = "Kumquat Tea",
            Description = "Iced green tea with kumquat and a touch of salt",
            CategoryId = 4,
            Price = 20000,
            ImageUrl = imageUrl
        }

    ];

    private static List<Food> OtherMenu() => [
        new Food
        {
            Name = "Ice",
            Description = "Cold ice",
            CategoryId = 5,
            Price = 5000,
            ImageUrl = imageUrl
        }
    ];
}
