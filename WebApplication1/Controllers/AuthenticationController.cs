using Application.Authentication.Commands.Register;
using Application.Authentication.Queries.Login;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Contracts.Authentication;

namespace WebApplication1.Controllers;

[Route("api/auth")]
public class AuthenticationController : ApiController
{
    private readonly ISender _sender;

    public AuthenticationController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        var query = new LoginQuery(request.UserName, request.Password);
        var result = await _sender.Send(query);

        if (result.IsSuccess && result.Value is not null)
        {
            return Ok(AuthenticationResponse.FromDomain(result.Value));
        }
        else
        {
            return Unauthorized(result.Errors);
        }
    }

    [HttpPost("customer-register")]
    public async Task<IActionResult> CustomerRegister([FromBody] CustomerRegisterRequest request)
    {
        var command = new CustomerRegisterCommand
        {
            UserName = request.UserName,
            Email = request.Email,
            Password = request.Password,
            PhoneNumber = request.PhoneNumber
        };

        var result = await _sender.Send(command);

        if (result.IsSuccess && result.Value is not null)
        {
            return Ok(AuthenticationResponse.FromDomain(result.Value));
        }
        else
        {
            return BadRequest(result.Errors);
        }
    }

    [HttpGet("testUser")]
    [Authorize(Roles = "User")]
    public async Task<IActionResult> TestUser()
    {
        await Task.CompletedTask;
        Console.WriteLine("test user");
        return Ok("User endpoint is accessible.");
    }
}
