using Application.Common.Requests;
using Application.Common.Results;

namespace Application.Carts.Commands.ClearCart;

public class ClearCartCommand : ICommand<Result>
{
    public Guid UserId { get; set; }

    public ClearCartCommand(Guid userId)
    {
        UserId = userId;
    }
}
