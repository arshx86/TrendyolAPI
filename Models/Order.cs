#region

using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

#endregion

namespace TrendyolAPI.Models
{
    public class Order
    {
        [JsonProperty("summary")] public Summary Summary { get; set; }

        [JsonProperty("items")] public List<Item> Items { get; set; }
    }
}