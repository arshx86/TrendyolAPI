using System.Linq;
using Newtonsoft.Json;

namespace TrendyolAPI.Models
{
    public class Hesap
    {
        [JsonProperty("user")]
        public User HesapBilgisi { get; set; }
    }
}