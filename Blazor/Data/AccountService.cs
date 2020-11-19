using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Model;

namespace Blazor.Data
{
    public class AccountService : IAccountService
    {
        private readonly HttpClient client;
        private string uri = "https://localhost:5001";

        public AccountService()
        {
            client = new HttpClient();
        }


        public async Task<Account> ValidateAccountAsync(string username, string password)
        {
            HttpResponseMessage response = await client.GetAsync($"https://localhost:5001/Accounts?username={username}&password={password}");
            if (response.StatusCode == HttpStatusCode.OK)
            {
                Console.WriteLine("the username is valid " + username);
                string userAsJson = await response.Content.ReadAsStringAsync();
                IList<Account> resultAccount = JsonSerializer.Deserialize<IList<Account>>(userAsJson);
                Account account = new Account();
                account = resultAccount.First();
                return account;
            } 
            throw new Exception("User not found");
        }

        public async Task<List<Account>> GetAccountsAsync()
        {
            Task<string> stringAsync = client.GetStringAsync(uri+"/Accounts");
            string message = await stringAsync;
            List<Account> result = JsonSerializer.Deserialize<List<Account>>(message);
            return result;
        }
        
        public async Task Register(Account newAccount)
        {
            string account = JsonSerializer.Serialize(newAccount);
            HttpContent content = new StringContent(account,
                Encoding.UTF8,
                "application/json");
            await client.PostAsync(uri+"/Accounts", content);
        }
    }
}