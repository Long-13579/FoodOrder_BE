using Application.Common.Requests;
using Application.Common.Results;

namespace Application.Carts.Commands.AddItemToCart;

public class AddItemToCartCommand : ICommand<Result>
{
    public int UserId { get; set; }
    public int FoodId { get; set; }
    public int Quantity { get; set; }

    public AddItemToCartCommand(int userId, int foodId, int quantity)
    {
        UserId = userId;
        FoodId = foodId;
        Quantity = quantity;
    }
}
