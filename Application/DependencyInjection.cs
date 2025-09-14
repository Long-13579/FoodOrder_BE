using Application.Behaviors;
using Application.Orders.Factories;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        //Add Application MediatR
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));

        //Add Application Factories
        services.AddTransient<IOrderFactory, OrderFactory>();

        //Add Application Behaviors
        services.AddBehaviors();

        return services;
    }
}
