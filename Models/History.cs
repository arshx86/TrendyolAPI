#region

using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

#endregion

namespace TrendyolAPI.Models
{
    public class History
    {
        [JsonProperty("result")] public List<Result> Histories { get; set; }

        [JsonProperty("error")] public string Error { get; set; }
    }
}