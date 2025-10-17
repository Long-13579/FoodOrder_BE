using Application.Common.Requests;
using Application.Common.Results;
using Domain;

namespace Application.Customers.Queries.GetCustomerById;

public record GetCustomerByIdQuery(
    Guid Id
) : IQuery<Result<Customer>>
{ }
