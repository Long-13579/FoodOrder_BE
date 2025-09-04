using Application.Common.Interfaces;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class FoodRepository : IFoodRepository
{
    private readonly AppDbContext _context;

    public FoodRepository(AppDbContext dataContext)
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

    public async Task<IEnumerable<Food>> GetAllFoodsAsync()
    {
        return await _context.Foods.ToListAsync();
    }

    public async Task<Food> GetFoodByIdAsync(int id)
    {
        return await _context.Foods.Where(x => x.Id == id).FirstAsync();
    }

    public async Task<IEnumerable<Food>> GetFoodsByCategoryAsync(FoodCategory category)
    {
        return await _context.Foods.Where(x => x.Category == category).ToListAsync();
    }

    public Task UpdateFoodAsync(Food food)
    {
        throw new NotImplementedException();
    }
}
