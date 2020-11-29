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
        SocketsToDatabase so;
        private IList<Account> accounts;

        public AccountService(){
            so = new SocketsToDatabase();
            accounts = new List<Account>();
        }

        public async Task<IList<Account>> getAccountsAsync()
        {
            accounts = (List<Account>) so.getAccounts();
            return accounts;
        }

        public async Task<Account> AddAccountAsync(Account account)
        {
            Account addedAccount = (Account)so.AddAccount(account);
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