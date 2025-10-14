using Application;
using Infrastructure;
using Infrastructure.Identity;
using Infrastructure.Persistance;
using Infrastructure.Persistance.Initializer;
using Microsoft.AspNetCore.Identity;
using WebApplication1;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
        .AddPresentation(builder.Configuration)
        .AddApplication()
        .AddInfrastructure(builder.Configuration);
}

var app = builder.Build();
{
    app.UseCors("AllowAll");
    app.UseExceptionHandler("/error");

    using (var scope = app.Services.CreateScope())
    {
        var services = scope.ServiceProvider;

        var dbContext = services.GetRequiredService<AppDbContext>();
        var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
        var roleManager = services.GetRequiredService<RoleManager<ApplicationRole>>();

        dbContext.Database.EnsureCreated();
        await DbInitializer.Initialize(dbContext, userManager, roleManager);
    }

    app.UseRouting();
    app.UseHttpsRedirection();
    app.UseAuthentication();
    app.UseAuthorization();
    app.MapControllers();
    app.Run();
}

