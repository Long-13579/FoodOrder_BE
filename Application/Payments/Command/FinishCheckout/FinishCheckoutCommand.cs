using Application.Common.Requests;
using Application.Common.Results;

namespace Application.Payments.Command.FinishCheckout;

public record FinishCheckoutCommand(string ExtraData) : ICommand<Result>
{
}
