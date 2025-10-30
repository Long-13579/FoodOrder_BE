using Application.Common.Models;
using Domain;

namespace Application.Common.Interfaces.Persistance.Repositories;

public interface IFoodRepository : IRepository<int>
{
    Task<IEnumerable<FoodDTO>> GetAllFoodsAsync();
    Task<FoodDTO?> GetFoodByIdAsync(int id);
    Task<IEnumerable<FoodDTO>> GetFoodsByCategoryAsync(int categoryId);
    Task AddFoodAsync(Food food);
    Task UpdateFoodAsync(Food food);
    Task DeleteFoodAsync(int id);
}
