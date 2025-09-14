using Application.Common.Requests;
using Application.Common.Results;
using Domain;

namespace Application.Carts.Queries.GetCartItemById;

public class GetCartItemByIdQuery : IQuery<Result<CartItem>>
{
    public int Id { get; set; }
    public GetCartItemByIdQuery(int id)
    {
        Id = id;
    }
}
