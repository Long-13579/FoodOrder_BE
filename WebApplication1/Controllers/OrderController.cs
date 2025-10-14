using Application.Orders.Commands.CreateOrder;
using Application.Orders.Queries.GetOrdersByUserId;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Contracts.Orders;
using WebApplication1.Utils;

namespace WebApplication1.Controllers;

[Authorize]
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
        var customerId = User.GetCustomerId();
        var command = new CreateOrderCommand(request.CartItemIds,
                                             customerId,
                                             request.CustomerName,
                                             request.CustomerEmail,
                                             request.CustomerPhone,
                                             request.CustomerAddress,
                                             request.Note);
        var result = await _sender.Send(command);

        return result.IsSuccess
            ? CreatedAtAction(nameof(GetOrdersByCustomerId), new { CustomerId = customerId }, null)
            : Problem(result.Errors);
    }

    [HttpGet("by-customerId")]
    public async Task<IActionResult> GetOrdersByCustomerId()
    {
        var customerId = User.GetCustomerId();
        var result = await _sender.Send(new GetOrdersByCustomerIdQuery(customerId));

        return result.IsSuccess 
            ? Ok(result.Value) 
            : Problem(result.Errors);
    }
}