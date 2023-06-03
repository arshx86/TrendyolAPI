using System.Linq;
using Newtonsoft.Json;

namespace TrendyolAPI.Models
{
    public class AResult
    {
        [JsonProperty("id")]
        public int? Id { get; set; }

        [JsonProperty("name")]
        public string Isim { get; set; }

        [JsonProperty("surname")]
        public string Soyisim { get; set; }

        [JsonProperty("phone")]
        public string Telefon { get; set; }

        [JsonProperty("identityNumber")]
        public object TCKimlikNumarasi { get; set; }

        [JsonProperty("maskedIdentityNumber")]
        public object TCKimlikNumarasiMaskeli { get; set; }

        [JsonProperty("email")]
        public object Email { get; set; }

        [JsonProperty("addressLine")]
        public string AdresSatiri { get; set; }

        [JsonProperty("addressName")]
        public string Adresİsmi { get; set; }

        [JsonProperty("postalCode")]
        public string PostaKodu { get; set; }

        [JsonProperty("countryCode")]
        public string UlkeKodu { get; set; }

        [JsonProperty("cityId")]
        public int? IlId { get; set; }

        [JsonProperty("cityName")]
        public string IlIsmi { get; set; }

        [JsonProperty("cityCode")]
        public string IlKodu { get; set; }

        [JsonProperty("districtId")]
        public int? YakinlikId { get; set; }

        [JsonProperty("districtName")]
        public string SehirIsmi { get; set; }

        [JsonProperty("neighborhoodId")]
        public int? NeighborhoodId { get; set; }

        [JsonProperty("neighborhoodName")]
        public string NeighborhoodName { get; set; }

        [JsonProperty("latitude")]
        public object Latitude { get; set; }

        [JsonProperty("longitude")]
        public object Longitude { get; set; }

        [JsonProperty("taxNumber")]
        public object TaxNumber { get; set; }

        [JsonProperty("maskedTaxNumber")]
        public object MaskedTaxNumber { get; set; }

        [JsonProperty("taxOffice")]
        public object TaxOffice { get; set; }

        [JsonProperty("company")]
        public object Company { get; set; }

        [JsonProperty("addressDescription")]
        public object AddressDescription { get; set; }

        [JsonProperty("apartmentNumber")]
        public object ApartmentNumber { get; set; }

        [JsonProperty("floor")]
        public object Floor { get; set; }

        [JsonProperty("doorNumber")]
        public object DoorNumber { get; set; }

        [JsonProperty("addressType")]
        public string AddressType { get; set; }

        [JsonProperty("isVerifiedPhone")]
        public object IsVerifiedPhone { get; set; }

        [JsonProperty("isEInvoiceAvailable")]
        public bool? IsEInvoiceAvailable { get; set; }

        [JsonProperty("isDistrictDeleted")]
        public bool IsDistrictDeleted { get; set; }

        [JsonProperty("isNeighborhoodDeleted")]
        public bool IsNeighborhoodDeleted { get; set; }
    }
}