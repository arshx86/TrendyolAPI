#region

using System.Linq;
using Newtonsoft.Json;

#endregion

namespace TrendyolAPI.Models
{
    public class Result
    {
        [JsonProperty("id")] public int Id { get; set; }

        [JsonProperty("url")] public string Url { get; set; }

        [JsonProperty("name")] public string Name { get; set; }
    }
}