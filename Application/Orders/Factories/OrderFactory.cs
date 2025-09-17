using Application.Common.Results;
using Application.Orders.Commands.CreateOrder;
using Application.Common.Errors;
using Domain;
using Application.Common.Interfaces.Persistance.Repositories;

namespace Application.Orders.Factories;

public class OrderFactory : IOrderFactory
{
    private readonly ICartRepository _cartRepository;

    public OrderFactory(ICartRepository cartRepository)
    {
        _cartRepository = cartRepository ?? throw new ArgumentNullException(nameof(cartRepository));
    }

    public async Task<Result<Order>> CreateAsync(CreateOrderCommand command)
    {
        var cartItems = await _cartRepository.GetCartItemByIdsAsync(command.UserId, command.CartItemIds);
        if (!cartItems.Any())
        {
            return Errors.CartItem.Empty();
        }

        if (cartItems.Count() != command.CartItemIds.Count())
        {
            return Errors.CartItem.SomeItemsInvalid();
        }

        var order = new Order
        {
            UserId = command.UserId,
            CustomerName = command.CustomerName,
            CustomerEmail = command.CustomerEmail,
            CustomerPhone = command.CustomerPhone,
            CustomerAddress = command.CustomerAddress,
            Note = command.Note ?? "Nothing",
            OrderItems = cartItems.Select(ci => new OrderItem
            {
                FoodId = ci.FoodId,
                Quantity = ci.Quantity,
                Price = ci.UnitPrice
            }).ToList()
        };

        return order;
    }
}
