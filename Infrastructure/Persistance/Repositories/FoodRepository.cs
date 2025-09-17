using Application.Common.Interfaces.Persistance.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistance.Repositories;

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

    public Task<bool> ExistsAsync(int id)
    {
        return _context.Foods.AnyAsync(x => x.Id == id);
    }

    public async Task<IEnumerable<Food>> GetAllFoodsAsync()
    {
        return await _context.Foods.ToListAsync();
    }

    public async Task<Food?> GetFoodByIdAsync(int id)
    {
        return await _context.Foods.Where(x => x.Id == id).FirstOrDefaultAsync();
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
