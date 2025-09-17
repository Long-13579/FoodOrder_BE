namespace Application.Common.Interfaces.Persistance.Repositories;

public interface IRepository<T>
{
    Task<bool> ExistsAsync(T id);
}
