using Application.Orders.Commands.CreateOrder;
using Application.Orders.Queries.GetOrdersByUserId;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Contracts.Orders;

namespace WebApplication1.Controllers;

[Route("api/order")]
public class OrderController : ApiController
{
    private readonly ISender _sender;

    public OrderController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPost]
    public async Task<IActionResult> AddOrder([FromBody] CreateOrderRequest request)
    {
        var command = new CreateOrderCommand(request.CartItemIds,
                                             request.UserId,
                                             request.CustomerName,
                                             request.CustomerEmail,
                                             request.CustomerPhone,
                                             request.CustomerAddress,
                                             request.Note);
        var result = await _sender.Send(command);

        return result.IsSuccess
            ? CreatedAtAction(nameof(GetOrdersByUserId), new { userId = request.UserId }, null)
            : Problem(result.Errors);
    }

    [HttpGet("by-userId/{userId:int}")]
    public async Task<IActionResult> GetOrdersByUserId(int userId)
    {
        var result = await _sender.Send(new GetOrdersByUserIdQuery(userId));

        return result.IsSuccess 
            ? Ok(result.Value) 
            : Problem(result.Errors);
    }
}