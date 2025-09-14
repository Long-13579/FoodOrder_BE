using Application.Common.Requests;
using Application.Common.Results;

namespace Application.Carts.Commands.ClearCart;

public class ClearCartCommand : ICommand<Result>
{
    public int UserId { get; set; }

    public ClearCartCommand(int userId)
    {
        UserId = userId;
    }
}
