using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using Database.Model;
using System.Threading.Tasks;
using Db;
using System.Collections.Generic;
using System.Linq;

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
            Server server = new Server(accountService,recipeService,addresService,shopIngrService);
            /*
            FirstSetup setup = new FirstSetup();
            List<Account> accounts = setup.GetAccounts();
            await tmp.saveAccountAsync(accounts[0]);
            await tmp.saveAccountAsync(accounts[1]);
            */
            server.start();
        }
        
        private static void Seed(DatabaseContext databaseContext)
        {
            Account[] acs = {
                new Account{
                    username = "Jannik",
                    password = "12345",
                    email = "Jannik@viauc.dk",
                },
                new Account{
                    username = "Dumi",
                    password = "yup",
                    email = "Dumi@viauc.dk",
                }
            };
            foreach (var account in acs)
            {
                databaseContext.accounts.Add(account);
            }

            databaseContext.SaveChanges();
        }
        
    }
    
    
}