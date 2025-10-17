using Application.Common.Requests;
using Application.Common.Results;

namespace Application.Carts.Commands.ClearCart;

public record ClearCartCommand(
    Guid CustomerId
) : ICommand<Result>
{ }
