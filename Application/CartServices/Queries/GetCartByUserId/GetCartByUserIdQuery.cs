using Domain;
using ErrorOr;
using MediatR;

namespace Application.CartServices.Queries.GetCartByUserId;

public class GetCartByUserIdQuery : IRequest<ErrorOr<List<CartItem>>>
{
    public string UserId { get; set; } = string.Empty;
    public GetCartByUserIdQuery(string userId)
    {
        UserId = userId;
    }
}
