using Application.Common.Interfaces.Payment;
using Application.Common.Models;
using Domain;
using Microsoft.Extensions.Options;
using System.Net.Http.Json;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace Infrastructure.Payment.Momo;

internal class MomoPayment : IMomoPayment
{
    private readonly MomoSettings _momoSettings;
    private readonly HttpClient _httpClient = new HttpClient();

    public MomoPayment(IOptions<MomoSettings> momoSettings)
    {
        _momoSettings = momoSettings.Value;
    }

    public async Task<string?> CreatePaymentUrl(OrderDTO order)
    {
        Guid transId = Guid.NewGuid();
        string accessKey = _momoSettings.AccessKey;
        string secretKey = _momoSettings.SecretKey;

        var extraDataDict = new Dictionary<string, string>
        {
            { "orderId", order.Id.ToString() },
        };

        MomoPaymentRequest request = new MomoPaymentRequest();
        request.orderInfo = "pay with MoMo";
        request.partnerCode = _momoSettings.PartnerCode;
        request.ipnUrl = _momoSettings.IpnUrl;
        request.redirectUrl = _momoSettings.RedirectUrl;
        request.amount = GetOrderAmount(order);
        request.orderId = transId.ToString();
        request.requestId = transId.ToString();
        request.requestType = _momoSettings.RequestType;
        request.extraData = CreateExtraData(extraDataDict);
        request.partnerName = _momoSettings.PartnerName;
        request.storeId = _momoSettings.StoreId;
        request.orderGroupId = "";
        request.autoCapture = true;
        request.lang = _momoSettings.Language;

        var rawSignature = "accessKey=" + accessKey + "&amount=" + request.amount + "&extraData=" + request.extraData + "&ipnUrl=" + request.ipnUrl + "&orderId=" + request.orderId + "&orderInfo=" + request.orderInfo + "&partnerCode=" + request.partnerCode + "&redirectUrl=" + request.redirectUrl + "&requestId=" + request.requestId + "&requestType=" + request.requestType;
        request.signature = GetSignature(rawSignature, secretKey);

        StringContent httpContent = new StringContent(JsonSerializer.Serialize(request), System.Text.Encoding.UTF8, "application/json");
        var quickPayResponse = await _httpClient.PostAsync("https://test-payment.momo.vn/v2/gateway/api/create", httpContent);
        var momoResponse = await quickPayResponse.Content.ReadFromJsonAsync<MomoPaymentResponse>();
        return momoResponse?.PayUrl;
    }

    private static long GetOrderAmount(OrderDTO order)
    {
        long amount = 0;

        foreach (var item in order.OrderItems)
        {
            amount += (long)(item.UnitPrice * item.Quantity);
        }

        return amount;
    }

    private static String GetSignature(String text, String key)
    {
        // change according to your needs, an UTF8Encoding
        // could be more suitable in certain situations
        ASCIIEncoding encoding = new ASCIIEncoding();

        Byte[] textBytes = encoding.GetBytes(text);
        Byte[] keyBytes = encoding.GetBytes(key);

        Byte[] hashBytes;

        using (HMACSHA256 hash = new HMACSHA256(keyBytes))
            hashBytes = hash.ComputeHash(textBytes);

        return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
    }

    private static string CreateExtraData(Dictionary<string, string> data)
    {
        if (data == null || data.Count == 0)
            return ""; // Default empty string

        string json = JsonSerializer.Serialize(data);
        byte[] bytes = Encoding.UTF8.GetBytes(json);
        return Convert.ToBase64String(bytes);
    }

    public Dictionary<string, string> DecodeExtraData(string base64Data)
    {
        var result = new Dictionary<string, string>();

        if (string.IsNullOrWhiteSpace(base64Data))
            return result; // Return empty dictionary if no data

        try
        {
            byte[] bytes = Convert.FromBase64String(base64Data);
            string json = Encoding.UTF8.GetString(bytes);

            result = JsonSerializer.Deserialize<Dictionary<string, string>>(json)
                     ?? new Dictionary<string, string>();
        }
        catch
        {
            // You could log or handle bad format here
        }

        return result;
    }
}
