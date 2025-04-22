using Domain;
using ErrorOr;
using MediatR;

namespace Application.CartServices.Commands.AddCartItem;

public class AddCartItemCommand : IRequest<ErrorOr<Unit>>
{
    public string UserId { get; set; } = string.Empty;
    public int FoodId { get; set; }
    public int Quantity { get; set; }
    public AddCartItemCommand(string userId, int foodId, int quantity)
    {
        UserId = userId;
        FoodId = foodId;
        Quantity = quantity;
    }
}
