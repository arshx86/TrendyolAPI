#region

using System.Linq;
using Newtonsoft.Json;

#endregion

namespace TrendyolAPI.Models
{
    public class Summary
    {
        [JsonProperty("isReady")] public bool IsReady { get; set; }

        [JsonProperty("isPaymentFailed")] public bool? IsPaymentFailed { get; set; }

        [JsonProperty("isCollectionPonişt?")] public bool IsCollectionPoint { get; set; }

        [JsonProperty("id")] public string Id { get; set; }

        [JsonProperty("orderNumber")] public string OrderNumber { get; set; }

        [JsonProperty("orderDate")] public long OrderDate { get; set; }

        [JsonProperty("fullName")] public string FullName { get; set; }

        [JsonProperty("deliveryAddressType")] public string DeliveryAddressType { get; set; }

        [JsonProperty("payment")] public Payment Payment { get; set; }

        [JsonProperty("counts")] public Counts Counts { get; set; }
    }
}