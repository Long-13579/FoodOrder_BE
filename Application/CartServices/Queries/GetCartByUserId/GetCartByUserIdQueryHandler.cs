using Application.Common.Interfaces;
using Application.Common.Errors;
using Domain;
using ErrorOr;
using MediatR;

namespace Application.CartServices.Queries.GetCartByUserId;

public class GetCartByUserIdQueryHandler : IRequestHandler<GetCartByUserIdQuery, ErrorOr<List<CartItem>>>
{
    private readonly ICartRepository _cartRepository;
    private readonly IUserRepository _userRepository;

    public GetCartByUserIdQueryHandler(ICartRepository cartRepository, IUserRepository userRepository)
    {
        _cartRepository = cartRepository;
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<List<CartItem>>> Handle(GetCartByUserIdQuery request, CancellationToken cancellationToken)
    {
        User? user = await _userRepository.GetUserByIdAsync(request.UserId);

        if (user is null)
        {
            return Errors.User.NotFound(request.UserId);
        }

        return await _cartRepository.GetCartByUserIdAsync(request.UserId);
    }
}
