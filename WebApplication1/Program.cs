using Application;
using Infrastructure;
using WebApplication1;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
        .AddPresentation()
        .AddApplicaiton()
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
    app.MapControllers();
    app.Run();
}

