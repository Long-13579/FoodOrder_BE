using Application.Common.Interfaces.Persistance.Repositories;
using Application.Common.Results;
using Domain;
using MediatR;

namespace Application.Customers.Commands.UpdateCustomer;

public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, Result<Customer>>
{
    private readonly ICustomerRepository _customerRepository;

    public UpdateCustomerCommandHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<Result<Customer>> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
    {
        var customerResult = await _customerRepository.GetByIdAsync(request.Id);
        if (!customerResult.IsSuccess)
            return customerResult.Errors;

        Customer customer = customerResult.Value!;
        customer.FirstName = request.FirstName;
        customer.LastName = request.LastName;
        customer.DateOfBirth = request.DateOfBirth;
        customer.Address = request.Address;

        var updateResult = await _customerRepository.UpdateAsync(customer);
        return updateResult;
    }
}
