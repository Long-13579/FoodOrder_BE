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

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequest request)
    {
        var command = new Application.Authentication.Commands.Register.RegisterCommand
        {
            UserName = request.UserName,
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            PhoneNumber = request.PhoneNumber,
            Password = request.Password,
            Address = request.Address,
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
    public IActionResult TestUser()
    {
        return Ok("User endpoint is accessible.");
    }
}
