using Application.Common.Errors;
using Application.Common.Interfaces;
using Application.Common.Results;
using Domain;

namespace Application.Services.Carts;

public class CartService : ICartService
{
    private readonly ICartRepository _cartRepository;
    private readonly ICartDomainService _cartDomainService;
    private readonly IUnitOfWork _unitOfWork;

    public CartService(ICartRepository cartRepository,
                       IUnitOfWork unitOfWork,
                       ICartDomainService cartDomainService)
    {
        _cartRepository = cartRepository ?? throw new ArgumentNullException(nameof(cartRepository));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        _cartDomainService = cartDomainService ?? throw new ArgumentNullException(nameof(cartDomainService));
    }

    public async Task<Result> AddItemToCartAsync(int userId, int foodId, int quantity)
    {
        var userResult = await _cartDomainService.EnsureUserExistsAsync(userId);
        if (!userResult.IsSuccess)
            return userResult.Error;

        var foodResult = await _cartDomainService.EnsureFoodExistsAsync(foodId);
        if (!foodResult.IsSuccess || foodResult.Value is null)
            return foodResult.Error;

        bool isQuantityValid = await _cartDomainService.ValidateQuantityAsync(quantity);
        if (!isQuantityValid)
            return Errors.CartItem.InvalidQuantity(quantity);

        var food = foodResult.Value;

        await _unitOfWork.BeginTransactionAsync();

        try
        {
            await _cartRepository.AddCartItemAsync(userId, food, quantity);

            await _unitOfWork.SaveChangesAsync();
            await _unitOfWork.CommitTransactionAsync();

            return Result.Success();
        }
        catch (Exception)
        {
            await _unitOfWork.RollbackTransactionAsync();
            throw;
        }
    }

    public async Task<Result> ClearCartAsync(int userId)
    {
        var userResult = await _cartDomainService.EnsureUserExistsAsync(userId);
        if (!userResult.IsSuccess)
            return userResult.Error;

        await _unitOfWork.BeginTransactionAsync();

        try
        {
            await _cartRepository.ClearCartAsync(userId);

            await _unitOfWork.SaveChangesAsync();
            await _unitOfWork.CommitTransactionAsync();

            return Result.Success();
        }
        catch (Exception)
        {
            await _unitOfWork.RollbackTransactionAsync();
            throw;
        }
    }

    public async Task<Result<IEnumerable<CartItem>>> GetCartByUserIdAsync(int userId)
    {
        var userResult = await _cartDomainService.EnsureUserExistsAsync(userId);
        if (!userResult.IsSuccess)
            return userResult.Error;

        var result = await _cartRepository.GetCartByUserIdAsync(userId);
        return result is null
            ? new List<CartItem>()
            : ResultFactory.From(result);
    }

    public async Task<Result<CartItem>> GetCartItemByIdAsync(int id)
    {
        var result = await _cartRepository.GetCartItemByIdAsync(id);
        return result is null
            ? Errors.CartItem.NotFound(id)
            : result;
    }

    public async Task<Result> RemoveItemFromCartAsync(int cartItemId)
    {
        var cartItemResult = await _cartDomainService.EnsureCartItemExistsAsync(cartItemId);
        if (!cartItemResult.IsSuccess)
            return cartItemResult.Error;

        await _unitOfWork.BeginTransactionAsync();

        try
        {
            await _cartRepository.DeleteCartItemAsync(cartItemId);

            await _unitOfWork.SaveChangesAsync();
            await _unitOfWork.CommitTransactionAsync();

            return Result.Success();
        }
        catch (Exception)
        {
            await _unitOfWork.RollbackTransactionAsync();
            throw;
        }
    }

    public async Task<Result> UpdateItemQuantityAsync(int cartItemId, int quantity)
    {
        var cartItemResult = await _cartDomainService.EnsureCartItemExistsAsync(cartItemId);
        if (!cartItemResult.IsSuccess)
            return cartItemResult.Error;

        bool isQuantityValid = await _cartDomainService.ValidateQuantityAsync(quantity);
        if (!isQuantityValid)
            return Errors.CartItem.InvalidQuantity(quantity);


        await _unitOfWork.BeginTransactionAsync();

        try
        {
            await _cartRepository.UpdateQuantityAsync(cartItemId, quantity);

            await _unitOfWork.SaveChangesAsync();
            await _unitOfWork.CommitTransactionAsync();

            return Result.Success();
        }
        catch (Exception)
        {
            await _unitOfWork.RollbackTransactionAsync();
            throw;
        }
    }
}
