using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace TrendyolAPI.Models
{
    public class OResults
    {
        [JsonProperty("hasNext")]
        public bool HasNext { get; set; }

        [JsonProperty("orders")]
        public List<Order> Orders { get; set; }
    }
}