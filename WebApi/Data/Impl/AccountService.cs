using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Database.Model;

using WebApi.Networking;

namespace Data.Impl
{
    public class AccountService : IAccountService
    {
        ISocketsToDatabase so;
        private IList<Account> accounts;
        private IList<Address> addresses;
        private IList<BankInfo> bankInfos;

        public AccountService(){
            so = new SocketsToDatabase();
            accounts = new List<Account>();
            addresses = new List<Address>();
            bankInfos = new List<BankInfo>();
        }

        public async Task<IList<Account>> getAccountsAsync()
        {
            accounts = (List<Account>) so.getAccounts();
            return accounts;
        }

        public async Task<IList<Address>> getAddressesAsync()
        {
            addresses = (List<Address>) so.getAddresses();
            return addresses;
        }
        
        public async Task<IList<BankInfo>> getBankInfosAsync()
        {
            bankInfos = (List<BankInfo>) so.getBankInfos();
            return bankInfos;
        }

        public async Task<Account> AddAccountAsync(Register register)
        {
            getAccountsAsync();
            foreach (var account in accounts)
            {
                if (account.username.Equals(register.account.username))
                {
                    return account;
                }
            }

            getAddressesAsync();
            foreach (var address in addresses)
            {
                if (address.street.Equals(register.address.street))
                {
                    if (!(address.city.Equals(register.address.city) && address.zipCode == register.address.zipCode))
                    {
                        return null;
                    }
                }
            }

            getBankInfosAsync();
            foreach (var bankInfo in bankInfos)
            {
                if (bankInfo.cardNumber == register.bankInfo.cardNumber)
                {
                    if (!(bankInfo.cardHolder.Equals(register.bankInfo.cardHolder)))
                    {
                        return null;
                    }
                }
            }
            Account addedAccount = (Account)so.AddAccount(register);
            return addedAccount;
        }
        

        /*public async Task<Account> ValidateUser(string username, string password)
        {
            Account user = (Account)so.ValidateUser(username, password);
            if (user != null)
            {
                return user;
            } 
            throw new Exception("User not found");
        }*/
    }
}