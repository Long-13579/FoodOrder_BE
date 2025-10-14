using Application.Common.Requests;
using Application.Common.Results;
using Domain;

namespace Application.Customers.Queries.GetCustomerById;

public class GetCustomerByIdQuery : IQuery<Result<Customer>>
{
    public Guid Id { get; set; }
}
