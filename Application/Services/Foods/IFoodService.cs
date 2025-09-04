using Application.Common.Results;
using Domain;

namespace Application.Services.Foods;

public interface IFoodService
{
    Task<Result<IEnumerable<Food>>> GetAllFoodsAsync();
    Task<Result<Food>> GetFoodByIdAsync(int id);
    Task<Result<IEnumerable<Food>>> GetFoodsByCategoryAsync(FoodCategory category);
    Task<Result> AddFoodAsync(Food food);
    Task<Result> UpdateFoodAsync(Food food);
    Task<Result> DeleteFoodAsync(int id);
}
