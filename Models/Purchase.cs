using System.Linq;
using Newtonsoft.Json;

namespace TrendyolAPI.Models
{
    public class Purchases
    {
        [JsonProperty("isSuccess")]
        public bool IsSuccess { get; set; }

        [JsonProperty("statusCode")]
        public int StatusCode { get; set; }

        [JsonProperty("error")]
        public object Error { get; set; }

        [JsonProperty("result")]
        public OResults Result { get; set; }

    }
}