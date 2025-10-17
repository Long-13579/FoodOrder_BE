using Application.Common.Requests;
using Application.Common.Results;

namespace Application.Carts.Commands.RemoveItemFromCart;

public record RemoveItemFromCartCommand(
    int CartItemId,
    Guid CustomerId
) : ICommand<Result>
{ }
