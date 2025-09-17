using Domain;

namespace Application.Common.Interfaces.Persistance.Repositories;

public interface IFoodRepository : IRepository<int>
{
    Task<IEnumerable<Food>> GetAllFoodsAsync();
    Task<Food?> GetFoodByIdAsync(int id);
    Task<IEnumerable<Food>> GetFoodsByCategoryAsync(FoodCategory category);
    Task AddFoodAsync(Food food);
    Task UpdateFoodAsync(Food food);
    Task DeleteFoodAsync(int id);
}
