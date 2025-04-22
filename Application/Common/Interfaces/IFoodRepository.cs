using Domain;

namespace Application.Common.Interfaces;

public interface IFoodRepository
{
    Task<List<Food>> GetAllFoodsAsync();
    Task<Food> GetFoodByIdAsync(int id);
    Task<List<Food>> GetFoodsByCategoryAsync(FoodCategory category);
    Task AddFoodAsync(Food food);
    Task UpdateFoodAsync(Food food);
    Task DeleteFoodAsync(int id);
}
