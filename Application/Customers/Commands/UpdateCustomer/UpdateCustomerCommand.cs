using Application.Common.Requests;
using Application.Common.Results;
using Domain;

namespace Application.Customers.Commands.UpdateCustomer;

public record UpdateCustomerCommand(
    Guid Id,
    string FirstName,
    string LastName,
    DateOnly DateOfBirth,
    string Address
) : ICommand<Result<Customer>>
{ }
