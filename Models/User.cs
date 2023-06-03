#region

using System.Linq;
using Newtonsoft.Json;

#endregion

namespace TrendyolAPI.Models
{
    public class User
    {
        [JsonProperty("firstName")] public string FirstName { get; set; }

        [JsonProperty("lastName")] public string LastName { get; set; }

        [JsonProperty("birthDate")] public BirthDate BirthDate { get; set; }

        [JsonProperty("gender")] public int? Gender { get; set; }

        [JsonProperty("phone")] public Phone Phone { get; set; }

        [JsonProperty("email")] public string Email { get; set; }

        [JsonProperty("hasUnknownEmail")] public string HasUnknownEmail { get; set; }

        [JsonProperty("userType")] public string UserType { get; set; }

        [JsonProperty("is2faActive")] public string Is2faActive { get; set; }

        [JsonProperty("isCorporate")] public string IsCorporate { get; set; }
    }
}