namespace Infrastructure.Payment.Momo;

internal class MomoSettings
{
    public string AccessKey { get; init; } = string.Empty;
    public string SecretKey { get; init; } = string.Empty;
    public string PartnerCode { get; init; } = string.Empty;
    public string RedirectUrl { get; init; } = string.Empty;
    public string IpnUrl { get; init; } = string.Empty;
    public string RequestType { get; init; } = string.Empty;
    public string PartnerName { get; init; } = string.Empty;
    public string StoreId { get; init; } = string.Empty;
    public string Language { get; init; } = string.Empty;

    public const string SectionName = "MomoSettings";
}
