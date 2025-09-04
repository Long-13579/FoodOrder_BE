using Application.Common.Errors;
using Application.Common.Interfaces;
using Application.Common.Results;
using Domain;

namespace Application.Services.Foods;

public class FoodService : IFoodService
{
    private readonly IFoodRepository _foodRepository;

    public FoodService(IFoodRepository foodRepository)
    {
        _foodRepository = foodRepository ?? throw new ArgumentNullException(nameof(foodRepository));
    }

    public Task<Result> AddFoodAsync(Food food)
    {
        throw new NotImplementedException();
    }

    public Task<Result> DeleteFoodAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<Result<IEnumerable<Food>>> GetAllFoodsAsync()
    {
        var result = await _foodRepository.GetAllFoodsAsync();
        return result is null
            ? new List<Food>()
            : ResultFactory.From(result);
    }

    public async Task<Result<Food>> GetFoodByIdAsync(int id)
    {
        return await _foodRepository.GetFoodByIdAsync(id);
    }

    public async Task<Result<IEnumerable<Food>>> GetFoodsByCategoryAsync(FoodCategory category)
    {
        var result = await _foodRepository.GetFoodsByCategoryAsync(category);
        return result is null
            ? new List<Food>()
            : ResultFactory.From(result);
    }

    public Task<Result> UpdateFoodAsync(Food food)
    {
        throw new NotImplementedException();
    }
}
