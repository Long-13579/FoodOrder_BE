using Application.Common.Interfaces.Persistance.Repositories;
using Application.Common.Models;
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

    public async Task<IEnumerable<FoodDTO>> GetAllFoodsAsync()
    {
        return await _context.Foods
            .Select(x => new FoodDTO
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Price = x.Price,
                ImageUrl = x.ImageUrl,
                CategoryId = x.CategoryId,
                CategoryName = x.Category.Name
            })
            .ToListAsync();
    }

    public async Task<FoodDTO?> GetFoodByIdAsync(int id)
    {
        return await _context.Foods
            .Where(x => x.Id == id)
            .Select(x => new FoodDTO
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Price = x.Price,
                ImageUrl = x.ImageUrl,
                CategoryId = x.CategoryId,
                CategoryName = x.Category.Name
            })
            .FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<FoodDTO>> GetFoodsByCategoryAsync(int categoryId)
    {
        return await _context.Foods
            .Where(x => x.CategoryId == categoryId)
            .Select(x => new FoodDTO
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Price = x.Price,
                ImageUrl = x.ImageUrl,
                CategoryId = x.CategoryId,
                CategoryName = x.Category.Name
            })
            .ToListAsync();
    }

    public Task UpdateFoodAsync(Food food)
    {
        throw new NotImplementedException();
    }
}
