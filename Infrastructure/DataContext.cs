using Domain;

namespace Infrastucture;

public class DataContext
{
    public List<Food> Foods { get; }
    public List<User> Users{ get; }
    public List<CartItem> Cart { get; }
    public List<Order> Orders { get; } 
    public List<OrderItem> OrderItems { get; }

    public DataContext()
    {
        Foods = AddMenu();
        Users = AddUser();
        Cart = new List<CartItem>();
        Orders = new List<Order>();
        OrderItems = new List<OrderItem>();
    }

    private List<Food> AddMenu()
    {
        var foods = new List<Food>();
        foods.AddRange(PhoMenu());
        foods.AddRange(BanhMiMenu());
        foods.AddRange(NoodleMenu());
        foods.AddRange(WaterMenu());
        foods.AddRange(OtherMenu());
        return foods;
    }

    private List<User> AddUser()
    {
        var users = new List<User>();
        users.Add(new User{
            UserId = "user01",
            Name = "Test User"
        });
        return users;
    }

    private List<Food> PhoMenu() => [
        new Food
        {
            Id = 1,
            Name = "Phở Bò Tái",
            Description = "Beef noodle soup with rare steak.",
            Category = FoodCategory.Pho,
            Price = 45000,
            ImageUrl = "Image/foodImage.png"
        },
        new Food
        {
            Id = 2,
            Name = "Phở Bò Chín",
            Description = "Beef noodle soup with well-done brisket.",
            Category = FoodCategory.Pho,
            Price = 45000,
            ImageUrl = "Image/foodImage.png"
        },
        new Food
        {
            Id = 3,
            Name = "Phở Gà",
            Description = "Chicken noodle soup with tender slices of chicken.",
            Category = FoodCategory.Pho,
            Price = 40000,
            ImageUrl = "Image/foodImage.png"
        },
        new Food
        {
            Id = 4,
            Name = "Phở Tái Gân",
            Description = "Beef noodle soup with rare steak and tendon.",
            Category = FoodCategory.Pho,
            Price = 50000,
            ImageUrl = "Image/foodImage.png"
        },
        new Food
        {
            Id = 5,
            Name = "Phở Tái Nạm",
            Description = "Beef noodle soup with rare steak and flank.",
            Category = FoodCategory.Pho,
            Price = 50000,
            ImageUrl = "Image/foodImage.png"
        },
        new Food
        {
            Id = 6,
            Name = "Phở Bò Viên",
            Description = "Beef noodle soup with beef meatballs.",
            Category = FoodCategory.Pho,
            Price = 45000,
            ImageUrl = "Image/foodImage.png"
        },
        new Food
        {
            Id = 7,
            Name = "Phở Sốt Vang",
            Description = "Pho with red wine stewed beef.",
            Category = FoodCategory.Pho,
            Price = 55000,
            ImageUrl = "Image/foodImage.png"
        },
        new Food
        {
            Id = 8,
            Name = "Phở Gà Xé Phay",
            Description = "Pho with shredded chicken and herbs.",
            Category = FoodCategory.Pho,
            Price = 40000,
            ImageUrl = "Image/foodImage.png"
        },
        new Food
        {
            Id = 9,
            Name = "Phở Bò Tái Lăn",
            Description = "Pho with stir-fried rare beef slices.",
            Category = FoodCategory.Pho,
            Price = 50000,
            ImageUrl = "Image/foodImage.png"
        },
        new Food
        {
            Id = 10,
            Name = "Phở Chay",
            Description = "Vegetarian pho with tofu and mushrooms.",
            Category = FoodCategory.Pho,
            Price = 38000,
            ImageUrl = "Image/foodImage.png"
        }
    ];

    private List<Food> BanhMiMenu() => [
        new Food
        {
            Id = 11,
            Name = "Bánh Mì Thịt Nướng",
            Description = "Grilled pork sandwich with pickled vegetables.",
            Category = FoodCategory.BanhMi,
            Price = 30000,
            ImageUrl = "Image/foodImage.png"
        },
        new Food
        {
            Id = 12,
            Name = "Bánh Mì Chả Lụa",
            Description = "Vietnamese pork sausage sandwich with cilantro and cucumber.",
            Category = FoodCategory.BanhMi,
            Price = 25000,
            ImageUrl = "Image/foodImage.png"
        },
        new Food
        {
            Id = 13,
            Name = "Bánh Mì Pate",
            Description = "Pate and butter sandwich with herbs and fresh veggies.",
            Category = FoodCategory.BanhMi,
            Price = 25000,
            ImageUrl = "Image/foodImage.png"
        },
        new Food
        {
            Id = 14,
            Name = "Bánh Mì Đặc Biệt",
            Description = "A combo sandwich with grilled pork, pate, and various meats.",
            Category = FoodCategory.BanhMi,
            Price = 35000,
            ImageUrl = "Image/foodImage.png"
        },
        new Food
        {
            Id = 15,
            Name = "Bánh Mì Gà",
            Description = "Chicken sandwich with vegetables and herbs.",
            Category = FoodCategory.BanhMi,
            Price = 28000,
            ImageUrl = "Image/foodImage.png"
        },
        new Food
        {
            Id = 16,
            Name = "Bánh Mì Bò",
            Description = "Beef sandwich with fresh cilantro and chili.",
            Category = FoodCategory.BanhMi,
            Price = 30000,
            ImageUrl = "Image/foodImage.png"
        },
        new Food
        {
            Id = 17,
            Name = "Bánh Mì Trứng",
            Description = "Egg sandwich with mayo and fresh vegetables.",
            Category = FoodCategory.BanhMi,
            Price = 22000,
            ImageUrl = "Image/foodImage.png"
        },
        new Food
        {
            Id = 18,
            Name = "Bánh Mì Xíu Mại",
            Description = "Pork meatball sandwich with pickled veggies and mayo.",
            Category = FoodCategory.BanhMi,
            Price = 28000,
            ImageUrl = "Image/foodImage.png"
        },
        new Food
        {
            Id = 19,
            Name = "Bánh Mì Chay",
            Description = "Vegetarian sandwich with tofu, mushrooms, and herbs.",
            Category = FoodCategory.BanhMi,
            Price = 25000,
            ImageUrl = "Image/foodImage.png"
        },
        new Food
        {
            Id = 20,
            Name = "Bánh Mì Tôm",
            Description = "Shrimp sandwich with mayonnaise and crunchy veggies.",
            Category = FoodCategory.BanhMi,
            Price = 32000,
            ImageUrl = "Image/foodImage.png"
        }
    ];

    private List<Food> NoodleMenu() => [
        new Food
        {
            Id = 21,
            Name = "Bún Chả",
            Description = "Grilled pork served with vermicelli noodles and dipping sauce.",
            Category = FoodCategory.Noodle,
            Price = 40000,
            ImageUrl = "Image/foodImage.png"
        },
        new Food
        {
            Id = 22,
            Name = "Bún Bò Huế",
            Description = "Spicy beef noodle soup from Huế with lemongrass and chili.",
            Category = FoodCategory.Noodle,
            Price = 45000,
            ImageUrl = "Image/foodImage.png"
        },
        new Food
        {
            Id = 23,
            Name = "Bún Thịt Nướng",
            Description = "Grilled pork on vermicelli with herbs and peanuts.",
            Category = FoodCategory.Noodle,
            Price = 40000,
            ImageUrl = "Image/foodImage.png"
        },
        new Food
        {
            Id = 24,
            Name = "Bún Mắm",
            Description = "Fermented fish broth noodle soup with seafood and pork.",
            Category = FoodCategory.Noodle,
            Price = 50000,
            ImageUrl = "Image/foodImage.png"
        },
        new Food
        {
            Id = 25,
            Name = "Bún Riêu",
            Description = "Crab and tomato soup with vermicelli noodles.",
            Category = FoodCategory.Noodle,
            Price = 42000,
            ImageUrl = "Image/foodImage.png"
        },
        new Food
        {
            Id = 26,
            Name = "Bún Gà Nướng",
            Description = "Grilled chicken with vermicelli and garlic fish sauce.",
            Category = FoodCategory.Noodle,
            Price = 38000,
            ImageUrl = "Image/foodImage.png"
        },
        new Food
        {
            Id = 27,
            Name = "Mì Quảng",
            Description = "Central Vietnamese turmeric noodles with shrimp and pork.",
            Category = FoodCategory.Noodle,
            Price = 45000,
            ImageUrl = "Image/foodImage.png"
        },
        new Food
        {
            Id = 28,
            Name = "Bún Nem Nướng",
            Description = "Grilled spring rolls with vermicelli and sweet dipping sauce.",
            Category = FoodCategory.Noodle,
            Price = 40000,
            ImageUrl = "Image/foodImage.png"
        },
        new Food
        {
            Id = 29,
            Name = "Hủ Tiếu Nam Vang",
            Description = "Phnom Penh-style noodle soup with pork and shrimp.",
            Category = FoodCategory.Noodle,
            Price = 48000,
            ImageUrl = "Image/foodImage.png"
        },
        new Food
        {
            Id = 30,
            Name = "Hủ Tiếu Xào",
            Description = "Stir-fried rice noodles with beef and vegetables.",
            Category = FoodCategory.Noodle,
            Price = 42000,
            ImageUrl = "Image/foodImage.png"
        }
    ];

    private List<Food> WaterMenu() => [
        new Food
        {
            Id = 31,
            Name = "Cheesy Pizza",
            Description = "Classic mozzarella pizza with tomato sauce",
            Category = FoodCategory.Water,
            Price = 9.99m,
            ImageUrl = "Image/foodImage.png"
        },
        new Food
        {
            Id = 32,
            Name = "Burger Delight",
            Description = "Juicy beef burger with crispy fries",
            Category = FoodCategory.Water,
            Price = 11.49m,
            ImageUrl = "Image/foodImage.png"
        },
        new Food
        {
            Id = 33,
            Name = "Sushi Combo",
            Description = "Fresh sushi platter with wasabi and soy sauce",
            Category = FoodCategory.Water,
            Price = 14.99m,
            ImageUrl = "Image/foodImage.png"
        }
    ];

    private List<Food> OtherMenu() => [
        new Food
        {
            Id = 34,
            Name = "Ice",
            Description = "Cold ice",
            Category = FoodCategory.Other,
            Price = 2.2m,
            ImageUrl = "Image/foodImage.png"
        }
    ];
}
