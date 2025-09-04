using Application.Common.Interfaces;
using Application.Services.Carts;
using Application.Common.Errors;
using Moq;

namespace Application.UnitTests.Services.Carts.CartServiceTests;

public class AddItemToCartTest
{
    private readonly Mock<ICartRepository> _cartRepositoryMock = new();
    private readonly Mock<ICartDomainService> _cartDomainServiceMock = new();
    private readonly Mock<IUnitOfWork> _unitOfWorkMock = new();
    private readonly CartService _cartService;

    public AddItemToCartTest()
    {
        _cartService = new CartService(
            _cartRepositoryMock.Object,
            _unitOfWorkMock.Object,
            _cartDomainServiceMock.Object);
    }

    [Fact]
    public async Task AddItemToCartAsync_ShouldReturnError_WhenUserDoesNotExist()
    {
        // Arrange
        int userId = 1;
        int foodId = 1;
        int quantity = 2;
        _cartDomainServiceMock
            .Setup(s => s.EnsureUserExistsAsync(userId))
            .ReturnsAsync(Errors.User.NotFound(userId));
        // Act
        var result = await _cartService.AddItemToCartAsync(userId, foodId, quantity);
        // Assert
        Assert.False(result.IsSuccess);
        Assert.Equal(Errors.User.NotFound(userId).Code, result.Error.Code);
    }

    [Fact]
    public async Task AddItemToCartAsync_ShouldReturnError_WhenFoodDoesNotExist()
    {
        // Arrange
        int userId = 1;
        int foodId = 1;
        int quantity = 2;
        _cartDomainServiceMock
            .Setup(s => s.EnsureUserExistsAsync(userId))
            .ReturnsAsync(new Domain.User { Id = userId });
        _cartDomainServiceMock
            .Setup(s => s.EnsureFoodExistsAsync(foodId))
            .ReturnsAsync(Errors.Food.NotFound(foodId));
        // Act
        var result = await _cartService.AddItemToCartAsync(userId, foodId, quantity);
        // Assert
        Assert.False(result.IsSuccess);
        Assert.Equal(Errors.Food.NotFound(foodId).Code, result.Error.Code);
    }

    [Fact]
    public async Task AddItemToCartAsync_ShouldReturnError_WhenQuantityIsInvalid()
    {
        // Arrange
        int userId = 1;
        int foodId = 1;
        int quantity = 0;
        _cartDomainServiceMock
            .Setup(s => s.EnsureUserExistsAsync(userId))
            .ReturnsAsync(new Domain.User { Id = userId });
        _cartDomainServiceMock
            .Setup(s => s.EnsureFoodExistsAsync(foodId))
            .ReturnsAsync(new Domain.Food { Id = foodId, Price = 10 });
        _cartDomainServiceMock
            .Setup(s => s.ValidateQuantityAsync(quantity))
            .ReturnsAsync(false);
        // Act
        var result = await _cartService.AddItemToCartAsync(userId, foodId, quantity);
        // Assert
        Assert.False(result.IsSuccess);
        Assert.Equal(Errors.CartItem.InvalidQuantity(quantity).Code, result.Error.Code);
    }
}
