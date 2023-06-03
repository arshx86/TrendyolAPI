using System.Linq;
using Newtonsoft.Json;

namespace TrendyolAPI.Models
{
    public class Phone
    {
        [JsonProperty("countryPhoneCode")]
        public string Code { get; set; }

        [JsonProperty("number")]
        public string Number { get; set; }

        [JsonProperty("status")]
        public int? Status { get; set; }

        [JsonProperty("type")]
        public int? Type { get; set; }
    }
}