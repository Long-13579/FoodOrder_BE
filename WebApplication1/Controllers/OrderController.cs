using Application.OrderServices.Commands.AddOrder;
using Application.OrderServices.Queries.GetOrderByUserId;
using Contract.Order;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers;

[Route("api/order")]
public class OrderController : ApiController
{
    private readonly ISender _mediator;

    public OrderController(ISender mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> AddOrder([FromBody] AddOrderRequest request)
    {
        var command = new AddOrderCommand
        {
            UserId = request.UserId,
            CustomerName = request.CustomerName,
            CustomerEmail = request.CustomerEmail,
            CustomerPhone = request.CustomerPhone,
            CustomerAddress = request.CustomerAddress,
            Note = request.Note,
            OrderItems = request.OrderItems.Select(item => new OrderItemCommand
            {
                FoodId = item.FoodId,
                Quantity = item.Quantity,
                Note = item.Note
            }).ToList()
        };
        var result = await _mediator.Send(command);

        return result.Match(
            orderId => CreatedAtAction(nameof(AddOrderCommandHandler), new { id = orderId }),
            errors => Problem(errors));
    }

    [HttpGet("by-userId/{userId}")]
    public async Task<IActionResult> GetOrdersByUserId(string userId)
    {
        var query = new GetOrderByUserIdQuery(userId);

        var result = await _mediator.Send(query);

        return result.Match(
            orders => Ok(orders),
            errors => Problem(errors));
    }
}