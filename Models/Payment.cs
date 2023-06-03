#region

using System.Linq;
using Newtonsoft.Json;

#endregion

namespace TrendyolAPI.Models
{
    public class Payment
    {
        [JsonProperty("cardTypeLogoUrl")] public string CardTypeLogoUrl { get; set; }

        [JsonProperty("cargo")] public double Cargo { get; set; }

        [JsonProperty("installmentCost")] public int InstallmentCost { get; set; }

        [JsonProperty("installmentCount")] public int InstallmentCount { get; set; }

        [JsonProperty("maskedCardNumber")] public string MaskedCardNumber { get; set; }

        [JsonProperty("methodName")] public string MethodName { get; set; }

        [JsonProperty("productSubTotal")] public double ProductSubTotal { get; set; }

        [JsonProperty("totalCharges")] public double TotalCharges { get; set; }
    }
}