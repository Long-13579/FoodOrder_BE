using Application;
using Infrastructure;
using Infrastructure.Persistance;
using Infrastructure.Persistance.Initializer;
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
        dbContext.Database.EnsureCreated();
        DbInitializer.Initialize(dbContext);
    }

    app.UseHttpsRedirection();
    app.UseAuthentication();
    app.UseAuthorization();
    app.MapControllers();
    app.Run();
}

