using Application.Common.Requests;
using Application.Common.Results;

namespace Application.Carts.Commands.AddItemToCart;

public class AddItemToCartCommand : ICommand<Result>
{
    public Guid CustomerId { get; init; }
    public int FoodId { get; init; }
    public int Quantity { get; init; }

    public AddItemToCartCommand(Guid customerId, int foodId, int quantity)
    {
        CustomerId = customerId;
        FoodId = foodId;
        Quantity = quantity;
    }
}
