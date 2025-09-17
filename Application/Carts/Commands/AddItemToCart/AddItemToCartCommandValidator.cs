using Application.Common.Interfaces.Persistance.Repositories;
using Application.Common.Validations;
using FluentValidation;

namespace Application.Carts.Commands.AddItemToCart;

public class AddItemToCartCommandValidator : AbstractValidator<AddItemToCartCommand>
{
    private readonly IFoodRepository _foodRepository;
    public AddItemToCartCommandValidator(IFoodRepository foodRepository)
    {
        _foodRepository = foodRepository;

        RuleFor(x => x.FoodId)
            .MustExist(FoodExists, "Food");
        RuleFor(x => x.Quantity)
            .NotEmpty().WithMessage("Quantity is required.")
            .GreaterThan(0).WithMessage("Quantity must be greater than 0.");
    }

    private async Task<bool> FoodExists(int foodId, CancellationToken cancellationToken)
        => await _foodRepository.ExistsAsync(foodId);
}
