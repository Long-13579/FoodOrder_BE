using Application.Common.Requests;
using Application.Common.Results;
using Domain;

namespace Application.Carts.Queries.GetCartItemById;

public record GetCartItemByIdQuery(
    int Id
) : IQuery<Result<CartItem>>
{ }
