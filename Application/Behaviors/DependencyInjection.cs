using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Behaviors;

public static class DependencyInjection
{
    public static IServiceCollection AddBehaviors(this IServiceCollection services)
    {
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(TransactionBehavior<,>));
        return services;
    }
}
