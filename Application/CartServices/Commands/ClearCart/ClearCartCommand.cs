using ErrorOr;
using MediatR;

namespace Application.CartServices.Commands.ClearCart;

public class ClearCartCommand : IRequest<ErrorOr<Unit>>
{
    public string UserId { get; set; } = string.Empty;
    public ClearCartCommand(string userId)
    {
        UserId = userId;
    }
}
