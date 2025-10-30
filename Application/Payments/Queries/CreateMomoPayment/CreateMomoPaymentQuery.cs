using Application.Common.Requests;
using Application.Common.Results;

namespace Application.Payments.Queries.CreateMomoPayment;

public record CreateMomoPaymentQuery(
    Guid OrderId,
    Guid CustomerId
) : IQuery<Result<string>> { }
