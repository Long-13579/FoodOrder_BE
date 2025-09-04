using Application.Common.Errors;
using Application.Common.Interfaces;
using Application.Common.Results;
using Domain;

namespace Application.Services.Orders;

public class OrderDomainService : IOrderDomainService
{
    private readonly IUserRepository _userRepository;

    public OrderDomainService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Result<User>> EnsureUserExistsAsync(int userId)
    {
        var result = await _userRepository.GetUserByIdAsync(userId);
        return result is null
            ? Errors.User.NotFound(userId)
            : result;
    }

    public async Task<Result> ValidateOrderAsync(Order order)
    {
        var result = await EnsureUserExistsAsync(order.UserId);
        if (!result.IsSuccess) {
            return result.Error;
        }

        if (!EnsureInformaitionNotNull(order))
        {
            return Errors.Order.MissInformation();
        }

        return Result.Success();
    }

    private bool EnsureInformaitionNotNull(Order order)
    {
        if (order.CustomerName is null
            || order.CustomerPhone is null
            || order.CustomerEmail is null
            || order.CustomerAddress is null)
        {
            return false;
        }

        if (order.CustomerName.Equals("")
            || order.CustomerPhone.Equals("")
            || order.CustomerEmail.Equals("")
            || order.CustomerAddress.Equals(""))
        {
            return false;
        }

        return true;
    }
}
