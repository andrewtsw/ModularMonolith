using System.Text.Json.Serialization;

namespace TCO.Einvoicing.Jde.Interfaces.Models
{
    public class AddressBookDto
    {
        [JsonPropertyName("taxId")]
        public string TaxId { get; set; }

        [JsonPropertyName("nameAlpha")]
        public string NameAlpha { get; set; }

        [JsonPropertyName("taxExemptionCertificate")]
        public string TaxExemptionCertificate { get; set; }

        [JsonPropertyName("addressLine1")]
        public string AddressLine1 { get; set; }

        [JsonPropertyName("addressLine2")]
        public string AddressLine2 { get; set; }

        [JsonPropertyName("addressLine3")]
        public string AddressLine3 { get; set; }

        [JsonPropertyName("addressLine4")]
        public string AddressLine4 { get; set; }

        [JsonPropertyName("city")]
        public string City { get; set; }

        [JsonPropertyName("country")]
        public string Country { get; set; }

        [JsonPropertyName("postalCode")]
        public string PostalCode { get; set; }
    }

}
