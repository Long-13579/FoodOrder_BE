using Domain;

namespace Application.Common.Interfaces.Persistance.Repositories;

public interface ICategoryRepository
{
    Task<bool> ExistsAsync(int id);
    Task<IEnumerable<Category>> GetAllAsync();
    Task<Category?> GetByIdAsync(int id);
    Task<Category?> GetByNameAsync(string name);
    Task UpdateAsync(Category category);
    Task DeleteAsync(int id);
}
