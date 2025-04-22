using Application.CartServices.Commands.AddCartItem;
using Application.CartServices.Commands.ClearCart;
using Application.CartServices.Commands.DeleteCartItem;
using Application.CartServices.Commands.UpdateQuantity;
using Application.CartServices.Queries.GetCartByUserId;
using Contract.Cart;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers;

[Route("api/cart")]
public class CartController : ApiController
{
    private readonly ISender _mediator;

    public CartController(ISender mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{userId}")]
    public async Task<IActionResult> GetCart(string userId)
    {
        var result = await _mediator.Send(new GetCartByUserIdQuery(userId));

        return result.Match(
            carts => Ok(CartItemResponse.FromDomain(carts)),
            errors => Problem(errors));
    }

    [HttpPost("add")]
    public async Task<IActionResult> AddToCart([FromBody] AddToCartRequest request)
    {
        AddCartItemCommand command = new(request.UserId, request.ProductId, request.Quantity);

        var result = await _mediator.Send(command);

        return result.Match(
            unit => Ok(),
            errors => Problem(errors));
    }

    [HttpPut("update")]
    public async Task<IActionResult> UpdateCartItem(UpdateCartItemRequest request)
    {
        var command = new UpdateQuantityCommand(request.CartItemId, request.Quantity);
        var result = await _mediator.Send(command);

        return result.Match(
            unit => Ok(),
            errors => Problem(errors));
    }

    [HttpDelete("remove/{cartItemId:int}")]
    public async Task<IActionResult> RemoveCartItem(int cartItemId)
    {
        var command = new DeleteCartItemCommand(cartItemId);

        await _mediator.Send(command);

        return Ok();
    }

    [HttpDelete("clear/{userId}")]
    public async Task<IActionResult> ClearCart(string userId)
    {
        var command = new ClearCartCommand(userId);
        var result = await _mediator.Send(command);

        return result.Match(
            unit => Ok(),
            errors => Problem(errors));
    }
}
