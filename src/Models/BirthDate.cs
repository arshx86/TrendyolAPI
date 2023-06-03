#region

using System.Linq;
using Newtonsoft.Json;

#endregion

namespace TrendyolAPI.Models
{
    public class BirthDate
    {
        [JsonProperty("day")] public int? Day { get; set; }

        [JsonProperty("month")] public int? Month { get; set; }

        [JsonProperty("year")] public int? Year { get; set; }
    }
}