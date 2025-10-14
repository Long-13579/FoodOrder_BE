using Domain.Constants;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Persistance.Initializer;

public static class DbInitializer
{
    public static async Task Initialize(AppDbContext context,
                                  UserManager<ApplicationUser> userManager,
                                  RoleManager<ApplicationRole> roleManager)
    {
        if (context.Foods.Any())
            return;

        var foods = InitialData.GenerateMenu();
        context.Foods.AddRange(foods);
        context.SaveChanges();

        var roles = InitialData.GenerateRoles();

        foreach (var role in roles)
        {
            if (!await roleManager.RoleExistsAsync(role.Name!))
            {
                await roleManager.CreateAsync(role);
            }
        }

        var defaultUserName = "DefaultUser";
        var defaultEmail = "test@gmail.com";
        var defaultUser = await userManager.FindByNameAsync(defaultUserName);

        if (defaultUser == null)
        {
            var user = new ApplicationUser
            {
                UserName = defaultUserName,
                Email = defaultEmail,
                PhoneNumber = "0123456789",
            };

            var result = await userManager.CreateAsync(user, "12345678"); // default password

            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, RoleNames.Customer);
                var customer = InitialData.GenerateCustomer(user.Id);
                await context.Customers.AddAsync(customer);
                await context.SaveChangesAsync();
            }
        }
    }

}
