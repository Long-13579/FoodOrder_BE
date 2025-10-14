using Application.Common.Requests;
using Application.Common.Results;
using Domain;

namespace Application.Customers.Commands.UpdateCustomer;

public class UpdateCustomerCommand : ICommand<Result<Customer>>
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public DateOnly DateOfBirth { get; set; }
    public string Address { get; set; } = string.Empty;
}
