namespace Database.Model
{
    public class AccountAddress
    {
        public string username { get; set; }
        public Account account { get; set; }
        public string street { get; set; }
        public Address address { get; set; }
    }
}