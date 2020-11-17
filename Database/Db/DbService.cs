using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Database.Model;

namespace Db
{
    public class DbService : IDbService
    {
        DatabaseContext ctx = new DatabaseContext();
        public async Task<List<Account>> GetAccountsAcyns()
        {
            List<Account> accounts = await ctx.accounts.ToListAsync();   
            return accounts;
        }

        public async Task removeAccountAsync(Account account)
        {
            ctx.Remove(account);
            await ctx.SaveChangesAsync();
        }

        public async Task saveAccountAsync(Account account)
        {
           await ctx.accounts.AddAsync(account);
           await ctx.SaveChangesAsync();
        }

        public async Task updateAccountAsync(Account account)
        {
            ctx.accounts.Update(account);
            await ctx.SaveChangesAsync();
        }
        
        public async Task<Account> ValidateUser(string username, string password)
        {
            Account account = ctx.accounts.FirstOrDefault(u => u.username.Equals(username) && u.password.Equals(password));
            return account;
        }
    }
}