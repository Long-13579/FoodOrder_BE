using Application.Common.Interfaces.Persistance;
using Application.Common.Interfaces.Persistance.Repositories;
using Application.Services.Carts;
using Domain;
using Moq;

namespace Application.UnitTests.Services.Carts.CartServiceTests;

public class GetCartByUserIdTests
{
    private readonly Mock<ICartRepository> _cartRepositoryMock = new();
    private readonly Mock<ICartDomainService> _cartDomainServiceMock = new();
    private readonly Mock<IUnitOfWork> _unitOfWorkMock = new();
    private readonly CartService _cartService;

    public GetCartByUserIdTests()
    {
        _cartService = new CartService(
            _cartRepositoryMock.Object,
            _unitOfWorkMock.Object,
            _cartDomainServiceMock.Object);
    }

    [Fact]
    public async Task GetCartByUserIdAsync_ShouldReturnCartItems_WhenUserExists()
    {
        // Arrange
        int userId = 1;
        var cartItems = new List<Domain.CartItem>
        {
            new CartItem { Id = 1, Quantity = 2, Food = new Food { Id = 1, Name = "Pizza", Price = 10 } },
            new CartItem { Id = 2, Quantity = 1, Food = new Food { Id = 2, Name = "Burger", Price = 5 } }
        };
        _cartDomainServiceMock
            .Setup(s => s.EnsureUserExistsAsync(userId))
            .ReturnsAsync(new User { Id = userId });
        _cartRepositoryMock
            .Setup(r => r.GetCartByUserIdAsync(userId))
            .ReturnsAsync(cartItems);
        // Act
        var result = await _cartService.GetCartByUserIdAsync(userId);
        // Assert
        Assert.True(result.IsSuccess);
        Assert.True(result.Value is not null);
        Assert.Equal(2, result.Value.Count());
        Assert.Contains(result.Value, ci => ci.Food.Name == "Pizza" && ci.Quantity == 2);
        Assert.Contains(result.Value, ci => ci.Food.Name == "Burger" && ci.Quantity == 1);
    }
}
