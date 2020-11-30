using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using Database.Model;
using System.Threading.Tasks;
using Db;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Server
{
    class Program
    {
        async static Task Main(string[] args)
        {
            using (DatabaseContext dataContext = new DatabaseContext())
            {
                if (!dataContext.accounts.Any())
                {
                    Seed(dataContext);
                }
            }
            IDbAccountService accountService = new DbAccountService();
            IDbRecipeService recipeService = new DbRecipeService();
            IDbAddressService addresService = new DbAddressService();
            IDbShopIngrService shopIngrService = new DbShopIngreService();
            IDbBankInfoService bankInfoService = new DbBankInfoService();
            Server server = new Server(accountService,recipeService,addresService,shopIngrService, bankInfoService);
            /*
            FirstSetup setup = new FirstSetup();
            List<Account> accounts = setup.GetAccounts();
            await tmp.saveAccountAsync(accounts[0]);
            await tmp.saveAccountAsync(accounts[1]);
            */
            server.start();
        }
        
        private static async Task Seed(DatabaseContext databaseContext)
        {
            Address[] addresses = {
                new Address{
                    street = "Solvgade 1, 3tv",
                    city = "Horsens",
                    zipCode = 8700,
                },
            };
            foreach (var address in addresses)
            {
                databaseContext.addresses.Add(address);
            }
            
            BankInfo[] bankInfos = {
                new BankInfo{
                    cardNumber = 123412341234,
                    cardHolder = "Pawel Skrzypkowski"
                },
            };
            foreach (var bankInfo in bankInfos)
            {
                databaseContext.bankInfos.Add(bankInfo);
            }

            
            Account[] acs = {
                new Account{
                    username = "Jannik",
                    password = "12345",
                    email = "Jannik@viauc.dk",
                },
            };
            foreach (var account in acs)
            {
                databaseContext.accounts.Add(account);
            }

            databaseContext.SaveChanges();
            
            Account steve = await databaseContext.accounts.FirstAsync(s => s.username.Equals("Jannik") );
            Address tek = await databaseContext.addresses.FirstAsync(c => c.street.Equals("Solvgade 1, 3tv"));
            AccountAddress sc = new AccountAddress()
            {
                address = tek,
                account = steve
            };
            
            steve.AccountAddresses = new List<AccountAddress>();
            steve.AccountAddresses.Add(sc);
            databaseContext.Update(steve);
            
            // ctx.Set<StudentCourse>().Add(sc); This is an alternative
            await databaseContext.SaveChangesAsync();
            
            Account steve2 = await databaseContext.accounts.FirstAsync(s => s.username.Equals("Jannik") );
            BankInfo bankInfo2 = await databaseContext.bankInfos.FirstAsync(c => c.cardNumber == 1234123412341234);
            AccountBankInfo sc2 = new AccountBankInfo()
            {
               account = steve2,
               bankInfo = bankInfo2
            };
            
            steve.AccountBankInfos = new List<AccountBankInfo>();
            steve.AccountBankInfos.Add(sc2);
            databaseContext.Update(steve2);
            
            // ctx.Set<StudentCourse>().Add(sc); This is an alternative
            await databaseContext.SaveChangesAsync();
            
        }
        
    }
    
    
}