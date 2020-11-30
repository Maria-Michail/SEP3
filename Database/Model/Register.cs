using System.Text.Json.Serialization;

namespace Database.Model
{
    public class Register
    {
        [JsonPropertyName("account")]
        public Account account { get; set; }
        [JsonPropertyName("address")]
        public Address address { get; set; }
        [JsonPropertyName("bankInfo")]
        public BankInfo bankInfo { get; set; }
    }
}