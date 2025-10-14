using Application.Common.Requests;
using Application.Common.Results;

namespace Application.Carts.Commands.ClearCart;

public class ClearCartCommand : ICommand<Result>
{
    public Guid CustomerId { get; init; }

    public ClearCartCommand(Guid customerId)
    {
        CustomerId = customerId;
    }
}
