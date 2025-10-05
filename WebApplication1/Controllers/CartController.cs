using Application.Carts.Commands.AddItemToCart;
using Application.Carts.Commands.ClearCart;
using Application.Carts.Commands.RemoveItemFromCart;
using Application.Carts.Commands.UpdateItemQuantity;
using Application.Carts.Queries.GetCartItemsByUserId;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Contracts.Carts;

namespace WebApplication1.Controllers;

[Route("api/cart")]
public class CartController : ApiController
{
    private readonly ISender _sender;

    public CartController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet("{userId:Guid}")]
    public async Task<IActionResult> GetCart(Guid userId)
    {
        var result = await _sender.Send(new GetCartItemsByUserIdQuery(userId));

        if (result.IsSuccess)
        {
            return result.Value is null
                ? Ok()
                : Ok(CartResponse.FromDomain(result.Value.ToList()));
        }
        else
        {
            return Problem(result.Errors);
        }
    }

    [HttpPost("add")]
    public async Task<IActionResult> AddToCart([FromBody] AddToCartRequest request)
    {
        var command = new AddItemToCartCommand(request.UserId,
                                               request.FoodId,
                                               request.Quantity);
        var result = await _sender.Send(command);

        return result.IsSuccess
            ? CreatedAtAction(nameof(GetCart), new { userId = request.UserId }, null)
            : Problem(result.Errors);
    }

    [HttpPut("update")]
    public async Task<IActionResult> UpdateCartItem(UpdateCartItemRequest request)
    {
        var command = new UpdateItemQuantityCommand(request.CartItemId,
                                                    request.Quantity);
        var result = await _sender.Send(command);

        return result.IsSuccess
            ? Ok()
            : Problem(result.Errors);
    }

    [HttpDelete("remove/{cartItemId:int}")]
    public async Task<IActionResult> RemoveCartItem(int cartItemId)
    {
        var result = await _sender.Send(new RemoveItemFromCartCommand(cartItemId));
        return result.IsSuccess 
            ? Ok() 
            : Problem(result.Errors);
    }

    [HttpDelete("clear/{userId:Guid}")]
    public async Task<IActionResult> ClearCart(Guid userId)
    {
        var result = await _sender.Send(new ClearCartCommand(userId));
        return result.IsSuccess 
            ? Ok() 
            : Problem(result.Errors);
    }
}
