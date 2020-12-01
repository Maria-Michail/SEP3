using System.Text.Json.Serialization;

namespace Database.Model
{
    public class RegisterAccount
    {
        
        [JsonPropertyName("account")]
        public Account account { get; set; }
        [JsonPropertyName("address")]
        public Address address { get; set; }
        [JsonPropertyName("bankInfo")]
        public BankInfo bankInfo { get; set; }
        
        public RegisterAccount()
        {
            account = new Account();
            address = new Address();
            bankInfo = new BankInfo();
        }
    }
}