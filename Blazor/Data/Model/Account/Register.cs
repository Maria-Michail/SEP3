using System.Text.Json.Serialization;

namespace Database.Model
{
    public class Register
    {
        public Account account { get; set; }
        public Address address { get; set; }
        public BankInfo bankInfo { get; set; }
    }
}