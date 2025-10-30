using System.Text;
using System.Text.Json;

namespace Infrastructure.Payment.Momo;

public static class MomoPaymentHelper
{
    public static Dictionary<string, string> DecodeExtraData(string base64Data)
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
