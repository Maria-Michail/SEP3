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
    public class DbAccountService : IDbAccountService
    {
        DatabaseContext ctx = new DatabaseContext();

        //Accounts
        public async Task<List<Account>> GetAccountsAcyns()
        {
            List<Account> accounts = await ctx.accounts.ToListAsync();   
            return accounts;
        }

        public async Task removeAccountAsync(Account account)
        {
            ctx.accounts.Remove(account);
            await ctx.SaveChangesAsync();
        }

        public async Task<Account> addAccountAsync(Account account)
        {
            foreach (var accountExists in ctx.accounts)
            {
                if (accountExists.username.Equals(account.username))
                {
                    return account;
                }
            }
            await ctx.accounts.AddAsync(account);
            await ctx.SaveChangesAsync();
            return account;
        }

        public async Task updateAccountAsync(Account account)
        {
            ctx.accounts.Update(account);
            await ctx.SaveChangesAsync();
        }
        
        public async Task LinkAddress(Account newaccount, Address newaddress)
        {
            Account account1 = await ctx.accounts.FirstAsync(s => s.username.Equals(newaccount.username) );
            Address address1 = await ctx.addresses.FirstAsync(c => c.street.Equals(newaddress.street));
            AccountAddress sc = new AccountAddress()
            {
                address = address1,
                account = account1
            };
            if (account1.AccountAddresses == null)
            {
                account1.AccountAddresses = new List<AccountAddress>();
            }
            account1.AccountAddresses.Add(sc);
            ctx.Update(account1);
            await ctx.SaveChangesAsync();
        }
        
        public async Task LinkBankInfo(Account newaccount, BankInfo newbankInfo)
        {
            Account account1 = await ctx.accounts.FirstAsync(s => s.username.Equals(newaccount.username) );
            BankInfo bankInfo1 = await ctx.bankInfos.FirstAsync(c => c.cardNumber == newbankInfo.cardNumber);
            AccountBankInfo sc2 = new AccountBankInfo()
            {
                account = account1,
                bankInfo = bankInfo1
            };
            if (account1.AccountBankInfos == null)
            {
                account1.AccountBankInfos = new List<AccountBankInfo>();
            }
            account1.AccountBankInfos.Add(sc2);
            ctx.Update(account1);
            await ctx.SaveChangesAsync();
        }
        /*public async Task<Account> ValidateUser(string username, string password)
        {
            Account account = ctx.accounts.FirstOrDefault(u => u.username.Equals(username) && u.password.Equals(password));
            Console.Write(account.username);
            return account;
        }*/
    }
}