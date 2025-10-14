using Application.Customers.Commands.UpdateCustomer;
using Application.Customers.Queries.GetCustomerById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebApplication1.Contracts.Customers;
using WebApplication1.Utils;

namespace WebApplication1.Controllers;

[Authorize]
[Route("api/customers")]
public class CustomerController : ApiController
{
    private readonly ISender _sender;
    public CustomerController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet("profile")]
    public async Task<IActionResult> GetCustomer()
    {
        var customerId = User.GetCustomerId();

        var query = new GetCustomerByIdQuery { Id = customerId};

        var customerResult = await _sender.Send(query);

        return customerResult.IsSuccess
            ? Ok(CustomerResponse.FromDomain(customerResult.Value!))
            : BadRequest(customerResult.Errors);
    }

    [HttpPut("update")]
    public async Task<IActionResult> UpdateCustomer([FromBody] UpdateCustomerRequest request)
    {
        var customerId = User.GetCustomerId();

        var command = new UpdateCustomerCommand
        {
            Id = customerId,
            FirstName = request.FirstName,
            LastName = request.LastName,
            DateOfBirth = request.DateOfBirth,
            Address = request.Address
        };

        var result = await _sender.Send(command);
        return result.IsSuccess 
            ? Ok(CustomerResponse.FromDomain(result.Value!))
            : BadRequest(result.Errors);
    }
}
