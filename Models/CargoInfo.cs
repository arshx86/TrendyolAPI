#region

using System.Linq;
using Newtonsoft.Json;

#endregion

namespace TrendyolAPI.Models
{
    public class CargoInfo
    {
        [JsonProperty("showMultipleBoxInfo")] public bool ShowMultipleBoxInfo { get; set; }

        [JsonProperty("providerName")] public string ProviderName { get; set; }

        [JsonProperty("trackingLink")] public string stringTrackingLink { get; set; }

        [JsonProperty("trackingNumber")] public string TrackingNumber { get; set; }

        [JsonProperty("deliveryType")] public string DeliveryType { get; set; }

        [JsonProperty("boxQuantity")] public int BoxQuantity { get; set; }
    }
}