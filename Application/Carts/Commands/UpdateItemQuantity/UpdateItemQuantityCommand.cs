using Application.Common.Requests;
using Application.Common.Results;

namespace Application.Carts.Commands.UpdateItemQuantity;

public record UpdateItemQuantityCommand(
    int CartItemId,
    int Quantity,
    Guid CustomerId
) : ICommand<Result>
{ }
