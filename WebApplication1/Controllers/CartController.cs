using Application.Services.Carts;
using Contract.Cart;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers;

[Route("api/cart")]
public class CartController : ApiController
{
    private readonly ICartService _cartService;

    public CartController(ICartService cartService)
    {
        _cartService = cartService ?? throw new ArgumentNullException(nameof(cartService));
    }

    [HttpGet("{userId:int}")]
    public async Task<IActionResult> GetCart(int userId)
    {
        var result = await _cartService.GetCartByUserIdAsync(userId);

        return result.IsSuccess
            ? Ok(result.Value)
            : BadRequest(result.Error);
    }

    [HttpPost("add")]
    public async Task<IActionResult> AddToCart([FromBody] AddToCartRequest request)
    {
        var result = await _cartService.AddItemToCartAsync(request.UserId, request.ProductId, request.Quantity);

        return result.IsSuccess
            ? CreatedAtAction(nameof(GetCart), new { userId = request.UserId }, null)
            : BadRequest(result.Error);
    }

    [HttpPut("update")]
    public async Task<IActionResult> UpdateCartItem(UpdateCartItemRequest request)
    {
        var result = await _cartService.UpdateItemQuantityAsync(request.CartItemId, request.Quantity);
        return result.IsSuccess
            ? Ok()
            : BadRequest(result.Error);
    }

    [HttpDelete("remove/{cartItemId:int}")]
    public async Task<IActionResult> RemoveCartItem(int cartItemId)
    {
        var result = await _cartService.RemoveItemFromCartAsync(cartItemId);
        return result.IsSuccess 
            ? Ok() 
            : BadRequest(result.Error);
    }

    [HttpDelete("clear/{userId:int}")]
    public async Task<IActionResult> ClearCart(int userId)
    {
        var result = await _cartService.ClearCartAsync(userId);
        return result.IsSuccess 
            ? Ok() 
            : BadRequest(result.Error);
    }
}
