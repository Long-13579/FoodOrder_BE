using Application.Services.Carts;
using Application.Services.Foods;
using Application.Services.Orders;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicaiton(this IServiceCollection services)
    {
        services.AddTransient<IOrderService, OrderService>();
        services.AddTransient<ICartService, CartService>();
        services.AddTransient<IFoodService, FoodService>();

        return services;
    }
}
