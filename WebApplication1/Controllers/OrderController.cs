using Application.Services.Orders;
using Contract.Order;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers;

[Route("api/order")]
public class OrderController : ApiController
{
    private readonly IOrderService _orderService;

    public OrderController(IOrderService orderService)
    {
        _orderService = orderService ?? throw new ArgumentNullException(nameof(orderService));
    }

    [HttpPost]
    public async Task<IActionResult> AddOrder([FromBody] AddOrderRequest request)
    {
        await _orderService.AddOrderAsync(request.ToDomain());
        return CreatedAtAction(nameof(GetOrdersByUserId), new { userId = request.UserId }, null);
    }

    [HttpGet("by-userId/{userId:int}")]
    public async Task<IActionResult> GetOrdersByUserId(int userId)
    {
        var orders = await _orderService.GetOrdersByUserIdAsync(userId);
        return Ok(orders);
    }
}