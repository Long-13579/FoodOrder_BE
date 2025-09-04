using Application.Common.Results;
using Domain;

namespace Application.Services.Orders;

public interface IOrderDomainService
{
    Task<Result> ValidateOrderAsync(Order order);
    Task<Result<User>> EnsureUserExistsAsync(int userId);
}
