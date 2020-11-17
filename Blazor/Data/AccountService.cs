using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
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
                string userAsJson = await response.Content.ReadAsStringAsync();
                Account resultAccount = JsonSerializer.Deserialize<Account>(userAsJson);
                return resultAccount;
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
    }
}