using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Database.Model;
using Model;

namespace Db
{
    public class DbService : IDbService
    {
        DatabaseContext ctx = new DatabaseContext();

        //Accounts
        public async Task<List<Account>> GetAccountsAcyns()
        {
            List<Account> accounts = await ctx.Accounts.ToListAsync();   
            return accounts;
        }

        public async Task removeAccountAsync(Account account)
        {
            ctx.Remove(account);
            await ctx.SaveChangesAsync();
        }

        public async Task saveAccountAsync(Account account)
        {
           await ctx.Accounts.AddAsync(account);
           await ctx.SaveChangesAsync();
        }

        public async Task updateAccountAsync(Account account)
        {
            ctx.Accounts.Update(account);
            await ctx.SaveChangesAsync();
        }
    }
}