using System.Linq;
using Newtonsoft.Json;

namespace TrendyolAPI.Models
{
    public class Item
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("shipmentNumber")]
        public uint ShipmentNumber { get; set; }

        [JsonProperty("date")]
        public object Date { get; set; }

        [JsonProperty("claimable")]
        public bool Claimable { get; set; }

        [JsonProperty("showCargoTrackingLink")]
        public bool ShowCargoTrackingLink { get; set; }

        [JsonProperty("isInstantDelivery")]
        public bool IsInstantDelivery { get; set; }

        [JsonProperty("cargoInfo")]
        public CargoInfo CargoInfo { get; set; }

        [JsonProperty("vasStatus")]
        public string VasStatus { get; set; }

        [JsonProperty("otpCode")]
        public string OtpCode { get; set; }
    }
}