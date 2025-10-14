using Application.Common.Results;
using Domain;

namespace Application.Common.Interfaces.Persistance.Repositories;

public interface ICustomerRepository
{
    Task<Result<Customer>> GetByUserIdAsync(Guid userId);
    Task<Result<Customer>> GetByIdAsync(Guid id);
    Task<Result> AddAsync(Customer customer);
    Task<Result<Customer>> UpdateAsync(Customer customer);
}
