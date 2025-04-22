using Application.Common.Interfaces;
using Domain;
using Infrastucture;

namespace Infrastructure.Repository;

public class FoodRepository : IFoodRepository
{
    private readonly DataContext _context;

    public FoodRepository(DataContext dataContext)
    {
        _context = dataContext;
    }

    public Task AddFoodAsync(Food food)
    {
        throw new NotImplementedException();
    }

    public Task DeleteFoodAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Food>> GetAllFoodsAsync()
    {
        await Task.Delay(10); // Simulate async operation
        return _context.Foods;
    }

    public async Task<Food> GetFoodByIdAsync(int id)
    {
        await Task.Delay(10); // Simulate async operation
        return _context.Foods.Where(x => x.Id == id).First();
    }

    public async Task<List<Food>> GetFoodsByCategoryAsync(FoodCategory category)
    {
        await Task.Delay(10); // Simulate async operation
        return _context.Foods.Where(x => x.Category == category).ToList();
    }

    public Task UpdateFoodAsync(Food food)
    {
        throw new NotImplementedException();
    }
}
