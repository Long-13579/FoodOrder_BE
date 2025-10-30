using Application.Common.Models;

namespace Application.Common.Interfaces.Payment;

public interface IMomoPayment
{
    Task<string?> CreatePaymentUrl(OrderDTO order);
    Dictionary<string, string> DecodeExtraData(string base64Data);
}
