namespace Database.Model
{
    public class AccountBankInfo
    {
        public string username { get; set; }
        public Account account { get; set; }
        public long cardNumber{ get; set; }
        public BankInfo bankInfo { get; set; }
    }
}