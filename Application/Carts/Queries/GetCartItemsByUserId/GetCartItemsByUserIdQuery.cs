using Application.Common.Requests;
using Application.Common.Results;
using Domain;

namespace Application.Carts.Queries.GetCartItemsByUserId;

public class GetCartItemsByUserIdQuery : IQuery<Result<IEnumerable<CartItem>>>
{
    public int UserId { get; set; }

    public GetCartItemsByUserIdQuery(int userId)
    {
        UserId = userId;
    }
}
