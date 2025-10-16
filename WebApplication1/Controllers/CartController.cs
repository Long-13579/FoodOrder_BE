using Application.Carts.Commands.AddItemToCart;
using Application.Carts.Commands.ClearCart;
using Application.Carts.Commands.RemoveItemFromCart;
using Application.Carts.Commands.UpdateItemQuantity;
using Application.Carts.Queries.GetCartItemsByCustomerId;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Contracts.Carts;
using WebApplication1.Utils;

namespace WebApplication1.Controllers;

[Authorize]
[Route("api/cart")]
public class CartController : ApiController
{
    private readonly ISender _sender;

    public CartController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet]
    public async Task<IActionResult> GetCart()
    {
        var customerId = User.GetCustomerId();

        var result = await _sender.Send(new GetCartItemsByCustomerIdQuery(customerId));

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
        var customerId = User.GetCustomerId();
        var command = new AddItemToCartCommand(customerId,
                                               request.FoodId,
                                               request.Quantity);
        var result = await _sender.Send(command);

        return result.IsSuccess
            ? CreatedAtAction(nameof(GetCart), new { }, null)
            : Problem(result.Errors);
    }

    [HttpPut("update")]
    public async Task<IActionResult> UpdateCartItem(UpdateCartItemRequest request)
    {
        var customerId = User.GetCustomerId();
        var command = new UpdateItemQuantityCommand(request.CartItemId,
                                                    request.Quantity,
                                                    customerId);
        var result = await _sender.Send(command);

        return result.IsSuccess
            ? Ok()
            : Problem(result.Errors);
    }

    [HttpDelete("remove/{cartItemId:int}")]
    public async Task<IActionResult> RemoveCartItem(int cartItemId)
    {
        var customerId = User.GetCustomerId();
        var result = await _sender.Send(new RemoveItemFromCartCommand(cartItemId, customerId));
        return result.IsSuccess 
            ? Ok() 
            : Problem(result.Errors);
    }

    [HttpDelete("clear")]
    public async Task<IActionResult> ClearCart()
    {
        var customerId = User.GetCustomerId();
        var result = await _sender.Send(new ClearCartCommand(customerId));
        return result.IsSuccess 
            ? Ok() 
            : Problem(result.Errors);
    }
}
