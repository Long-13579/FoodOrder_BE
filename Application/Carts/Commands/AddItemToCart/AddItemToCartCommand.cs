using Application.Common.Requests;
using Application.Common.Results;

namespace Application.Carts.Commands.AddItemToCart;

public record AddItemToCartCommand(
    Guid CustomerId,
    int FoodId,
    int Quantity
) : ICommand<Result>
{ }
