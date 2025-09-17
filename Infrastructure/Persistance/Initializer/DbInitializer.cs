using Domain;

namespace Infrastructure.Persistance.Initializer;

public static class DbInitializer
{
    public static void Initialize(AppDbContext context)
    {
        if (context.Foods.Any())
            return;

        var foods = InitialData.GenerateMenu();
        context.Foods.AddRange(foods);
        context.SaveChanges();

        var users = InitialData.GenerateUsers();
        context.Users.AddRange(users);
        context.SaveChanges();
    }

}
