using Application.Common.Errors;
using Application.Common.Interfaces.Persistance.Repositories;
using Application.Common.Results;
using MediatR;

namespace Application.Carts.Commands.AddItemToCart;

public class AddItemToCartCommandHandler : IRequestHandler<AddItemToCartCommand, Result>
{
    private readonly ICartRepository _cartRepository;
    private readonly IFoodRepository _foodRepository;
    private readonly ICustomerRepository _customerRepository;

    public AddItemToCartCommandHandler(ICartRepository cartRepository,
                                       IFoodRepository foodRepository,
                                       ICustomerRepository customerRepository)
    {
        _cartRepository = cartRepository ?? throw new ArgumentNullException(nameof(cartRepository));
        _foodRepository = foodRepository ?? throw new ArgumentNullException(nameof(foodRepository));
        _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
    }

    public async Task<Result> Handle(AddItemToCartCommand request, CancellationToken cancellationToken)
    {
        var customerResult = await _customerRepository.GetByIdAsync(request.CustomerId);
        if (!customerResult.IsSuccess)
            return customerResult.Errors;

        var food = await _foodRepository.GetFoodByIdAsync(request.FoodId);
        if (food is null)
            return Errors.Food.NotFound(request.FoodId);

        await _cartRepository.AddCartItemAsync(request.CustomerId, food, request.Quantity);

        return Result.Success();
    }
}
