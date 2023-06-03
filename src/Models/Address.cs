#region

using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

#endregion

namespace TrendyolAPI.Models
{
    public class Address
    {
        [JsonProperty("isSuccess")] public bool IsSuccess { get; set; }

        [JsonProperty("statusCode")] public int? StatusCode { get; set; }

        [JsonProperty("error")] public object Error { get; set; }

        [JsonProperty("result")] public List<AResult> Result { get; set; }
    }
}