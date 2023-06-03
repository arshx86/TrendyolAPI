using System.Linq;
using Newtonsoft.Json;

namespace TrendyolAPI.Models
{
    public class Card
    {
        [JsonProperty("cardId")]
        public int CardId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("maskedCardNumber")]
        public string MaskedCardNumber { get; set; }

        [JsonProperty("cardType")]
        public int CardType { get; set; }

        [JsonProperty("cardTypeName")]
        public string CardTypeName { get; set; }

        [JsonProperty("bankName")]
        public string BankName { get; set; }

        [JsonProperty("isDebitCard")]
        public bool IsDebitCard { get; set; }

        [JsonProperty("cvvRequired")]
        public bool CvvRequired { get; set; }

        [JsonProperty("bankLogoUrl")]
        public string BankLogoUrl { get; set; }

        [JsonProperty("cardYear")]
        public int CardYear { get; set; }

        [JsonProperty("cardMonth")]
        public int CardMonth { get; set; }

        [JsonProperty("cardTypeLogoUrl")]
        public string CardTypeLogoUrl { get; set; }
    }
}