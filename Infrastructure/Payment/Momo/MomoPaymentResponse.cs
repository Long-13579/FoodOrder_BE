namespace Infrastructure.Payment.Momo;

internal class MomoPaymentResponse
{
    public string PartnerCode { get; set; } = string.Empty;
    public string OrderId { get; set; } = string.Empty;
    public string RequestId { get; set; } = string.Empty;
    public decimal Amount { get; set; }
    public long ResponseTime { get; set; }
    public string Message { get; set; } = string.Empty;
    public int ResultCode { get; set; }
    public string PayUrl { get; set; } = string.Empty;
    public string ShortLink { get; set; } = string.Empty;
}
