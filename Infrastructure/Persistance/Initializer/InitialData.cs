using Domain;

namespace Infrastructure.Persistance.Initializer;

public static class InitialData
{
    public static List<User> GenerateUsers()
    {
        var users = new List<User>();
        users.Add(new User
        {
            Name = "Test User"
        });
        return users;
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
            Category = FoodCategory.Pho,
            Price = 45000,
            ImageUrl = "Image/foodImage.png"
        },
        new Food
        {
            Name = "Phở Bò Chín",
            Description = "Beef noodle soup with well-done brisket.",
            Category = FoodCategory.Pho,
            Price = 45000,
            ImageUrl = "Image/foodImage.png"
        },
        new Food
        {
            Name = "Phở Gà",
            Description = "Chicken noodle soup with tender slices of chicken.",
            Category = FoodCategory.Pho,
            Price = 40000,
            ImageUrl = "Image/foodImage.png"
        },
        new Food
        {
            Name = "Phở Tái Gân",
            Description = "Beef noodle soup with rare steak and tendon.",
            Category = FoodCategory.Pho,
            Price = 50000,
            ImageUrl = "Image/foodImage.png"
        },
        new Food
        {
            Name = "Phở Tái Nạm",
            Description = "Beef noodle soup with rare steak and flank.",
            Category = FoodCategory.Pho,
            Price = 50000,
            ImageUrl = "Image/foodImage.png"
        },
        new Food
        {
            Name = "Phở Bò Viên",
            Description = "Beef noodle soup with beef meatballs.",
            Category = FoodCategory.Pho,
            Price = 45000,
            ImageUrl = "Image/foodImage.png"
        },
        new Food
        {
            Name = "Phở Sốt Vang",
            Description = "Pho with red wine stewed beef.",
            Category = FoodCategory.Pho,
            Price = 55000,
            ImageUrl = "Image/foodImage.png"
        },
        new Food
        {
            Name = "Phở Gà Xé Phay",
            Description = "Pho with shredded chicken and herbs.",
            Category = FoodCategory.Pho,
            Price = 40000,
            ImageUrl = "Image/foodImage.png"
        },
        new Food
        {
            Name = "Phở Bò Tái Lăn",
            Description = "Pho with stir-fried rare beef slices.",
            Category = FoodCategory.Pho,
            Price = 50000,
            ImageUrl = "Image/foodImage.png"
        },
        new Food
        {
            Name = "Phở Chay",
            Description = "Vegetarian pho with tofu and mushrooms.",
            Category = FoodCategory.Pho,
            Price = 38000,
            ImageUrl = "Image/foodImage.png"
        }
];

    private static List<Food> BanhMiMenu() => [
        new Food
        {
            Name = "Bánh Mì Thịt Nướng",
            Description = "Grilled pork sandwich with pickled vegetables.",
            Category = FoodCategory.BanhMi,
            Price = 30000,
            ImageUrl = "Image/foodImage.png"
        },
        new Food
        {
            Name = "Bánh Mì Chả Lụa",
            Description = "Vietnamese pork sausage sandwich with cilantro and cucumber.",
            Category = FoodCategory.BanhMi,
            Price = 25000,
            ImageUrl = "Image/foodImage.png"
        },
        new Food
        {
            Name = "Bánh Mì Pate",
            Description = "Pate and butter sandwich with herbs and fresh veggies.",
            Category = FoodCategory.BanhMi,
            Price = 25000,
            ImageUrl = "Image/foodImage.png"
        },
        new Food
        {
            Name = "Bánh Mì Đặc Biệt",
            Description = "A combo sandwich with grilled pork, pate, and various meats.",
            Category = FoodCategory.BanhMi,
            Price = 35000,
            ImageUrl = "Image/foodImage.png"
        },
        new Food
        {
            Name = "Bánh Mì Gà",
            Description = "Chicken sandwich with vegetables and herbs.",
            Category = FoodCategory.BanhMi,
            Price = 28000,
            ImageUrl = "Image/foodImage.png"
        },
        new Food
        {
            Name = "Bánh Mì Bò",
            Description = "Beef sandwich with fresh cilantro and chili.",
            Category = FoodCategory.BanhMi,
            Price = 30000,
            ImageUrl = "Image/foodImage.png"
        },
        new Food
        {
            Name = "Bánh Mì Trứng",
            Description = "Egg sandwich with mayo and fresh vegetables.",
            Category = FoodCategory.BanhMi,
            Price = 22000,
            ImageUrl = "Image/foodImage.png"
        },
        new Food
        {
            Name = "Bánh Mì Xíu Mại",
            Description = "Pork meatball sandwich with pickled veggies and mayo.",
            Category = FoodCategory.BanhMi,
            Price = 28000,
            ImageUrl = "Image/foodImage.png"
        },
        new Food
        {
            Name = "Bánh Mì Chay",
            Description = "Vegetarian sandwich with tofu, mushrooms, and herbs.",
            Category = FoodCategory.BanhMi,
            Price = 25000,
            ImageUrl = "Image/foodImage.png"
        },
        new Food
        {
            Name = "Bánh Mì Tôm",
            Description = "Shrimp sandwich with mayonnaise and crunchy veggies.",
            Category = FoodCategory.BanhMi,
            Price = 32000,
            ImageUrl = "Image/foodImage.png"
        }
    ];

    private static List<Food> NoodleMenu() => [
        new Food
        {
            Name = "Bún Chả",
            Description = "Grilled pork served with vermicelli noodles and dipping sauce.",
            Category = FoodCategory.Noodle,
            Price = 40000,
            ImageUrl = "Image/foodImage.png"
        },
        new Food
        {
            Name = "Bún Bò Huế",
            Description = "Spicy beef noodle soup from Huế with lemongrass and chili.",
            Category = FoodCategory.Noodle,
            Price = 45000,
            ImageUrl = "Image/foodImage.png"
        },
        new Food
        {
            Name = "Bún Thịt Nướng",
            Description = "Grilled pork on vermicelli with herbs and peanuts.",
            Category = FoodCategory.Noodle,
            Price = 40000,
            ImageUrl = "Image/foodImage.png"
        },
        new Food
        {
            Name = "Bún Mắm",
            Description = "Fermented fish broth noodle soup with seafood and pork.",
            Category = FoodCategory.Noodle,
            Price = 50000,
            ImageUrl = "Image/foodImage.png"
        },
        new Food
        {
            Name = "Bún Riêu",
            Description = "Crab and tomato soup with vermicelli noodles.",
            Category = FoodCategory.Noodle,
            Price = 42000,
            ImageUrl = "Image/foodImage.png"
        },
        new Food
        {
            Name = "Bún Gà Nướng",
            Description = "Grilled chicken with vermicelli and garlic fish sauce.",
            Category = FoodCategory.Noodle,
            Price = 38000,
            ImageUrl = "Image/foodImage.png"
        },
        new Food
        {
            Name = "Mì Quảng",
            Description = "Central Vietnamese turmeric noodles with shrimp and pork.",
            Category = FoodCategory.Noodle,
            Price = 45000,
            ImageUrl = "Image/foodImage.png"
        },
        new Food
        {
            Name = "Bún Nem Nướng",
            Description = "Grilled spring rolls with vermicelli and sweet dipping sauce.",
            Category = FoodCategory.Noodle,
            Price = 40000,
            ImageUrl = "Image/foodImage.png"
        },
        new Food
        {
            Name = "Hủ Tiếu Nam Vang",
            Description = "Phnom Penh-style noodle soup with pork and shrimp.",
            Category = FoodCategory.Noodle,
            Price = 48000,
            ImageUrl = "Image/foodImage.png"
        },
        new Food
        {
            Name = "Hủ Tiếu Xào",
            Description = "Stir-fried rice noodles with beef and vegetables.",
            Category = FoodCategory.Noodle,
            Price = 42000,
            ImageUrl = "Image/foodImage.png"
        }
    ];

    private static List<Food> WaterMenu() => [
        new Food
        {
            Name = "Peach Tea",
            Description = "Refreshing peach tea with real peach slices",
            Category = FoodCategory.Water,
            Price = 10000,
            ImageUrl = "Image/foodImage.png"
        },
        new Food
        {
            Name = "Sugarcane Juice",
            Description = "Freshly pressed sugarcane juice, served cold",
            Category = FoodCategory.Water,
            Price = 12000,
            ImageUrl = "Image/foodImage.png"
        },
        new Food
        {
            Name = "Soy Milk",
            Description = "Nutritious soy milk, served hot or cold",
            Category = FoodCategory.Water,
            Price = 15000,
            ImageUrl = "Image/foodImage.png"
        },
        new Food
        {
            Name = "Vietnamese Iced Coffee",
            Description = "Traditional Vietnamese drip coffee with condensed milk",
            Category = FoodCategory.Water,
            Price = 10000,
            ImageUrl = "Image/foodImage.png"
        },
        new Food
        {
            Name = "Kumquat Tea",
            Description = "Iced green tea with kumquat and a touch of salt",
            Category = FoodCategory.Water,
            Price = 20000,
            ImageUrl = "Image/foodImage.png"
        }

    ];

    private static List<Food> OtherMenu() => [
        new Food
        {
            Name = "Ice",
            Description = "Cold ice",
            Category = FoodCategory.Other,
            Price = 5000,
            ImageUrl = "Image/foodImage.png"
        }
    ];
}
