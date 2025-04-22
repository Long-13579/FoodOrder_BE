using Application;
using Infrastructure;
using WebApplication1;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
        .AddPresentation()
        .AddApplicaiton()
        .AddInfrastructure();
}

var app = builder.Build();
{
    app.UseCors("AllowAll");
    app.UseExceptionHandler("/error");
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}

