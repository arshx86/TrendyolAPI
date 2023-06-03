#region

using System.Linq;
using Newtonsoft.Json;

#endregion

namespace TrendyolAPI.Models
{
    public class Account
    {
        [JsonProperty("user")] public User UserInfo { get; set; }
    }
}