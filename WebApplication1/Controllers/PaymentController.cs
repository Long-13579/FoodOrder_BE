using Application.Payments.Command.FinishCheckout;
using Application.Payments.Queries.CreateMomoPayment;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Utils;

namespace WebApplication1.Controllers;

[Authorize]
[Route("/api/payment")]
public class PaymentController : ApiController
{
    private readonly ISender _sender;

    public PaymentController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet("momo")]
    public async Task<IActionResult> CreateMomoPayment([FromQuery] Guid orderId)
    {
        var customerId = User.GetCustomerId();
        var result = await _sender.Send(new CreateMomoPaymentQuery(orderId, customerId));
        return result.IsSuccess
            ? Ok(new { payUrl = result.Value })
            : Problem(result.Errors);
    }

    [HttpPut("momo/finish")]
    public async Task<IActionResult> FinishMomoPayment([FromQuery] string extraData)
    {
        var result = await _sender.Send(new FinishCheckoutCommand(extraData));
        return result.IsSuccess
            ? Ok()
            : Problem(result.Errors);
    }
}
