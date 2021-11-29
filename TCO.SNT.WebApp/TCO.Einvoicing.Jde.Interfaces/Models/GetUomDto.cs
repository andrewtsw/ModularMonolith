using System.Text.Json.Serialization;

namespace TCO.Einvoicing.Jde.Interfaces.Models
{
    public class GetUomDto
    {
        [JsonPropertyName("userDefinedCode")]
        public string UserDefinedCode { get; set; }

        [JsonPropertyName("userReservedReference")]
        public string UserReservedReference { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }
    }

}
