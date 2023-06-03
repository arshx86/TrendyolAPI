#region

using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

#endregion

namespace TrendyolAPI.Models
{
    public class OResults
    {
        [JsonProperty("hasNext")] public bool HasNext { get; set; }

        [JsonProperty("orders")] public List<Order> Orders { get; set; }
    }
}