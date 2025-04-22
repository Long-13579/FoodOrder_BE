using Application.Common.Interfaces;
using Application.Common.Errors;
using ErrorOr;
using MediatR;
using Domain;

namespace Application.CartServices.Commands.ClearCart;

public class ClearCartCommandHandler : IRequestHandler<ClearCartCommand, ErrorOr<Unit>>
{
    private readonly ICartRepository _cartRepository;
    private readonly IUserRepository _userRepository;

    public ClearCartCommandHandler(ICartRepository cartRepository, IUserRepository userRepository)
    {
        _cartRepository = cartRepository;
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<Unit>> Handle(ClearCartCommand request, CancellationToken cancellationToken)
    {
        User? user = await _userRepository.GetUserByIdAsync(request.UserId);

        if (user is null)
        {
            return Errors.User.NotFound(request.UserId);
        }

        await _cartRepository.ClearCartAsync(request.UserId);

        return Unit.Value;
    }
}
