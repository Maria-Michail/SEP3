using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Database.Model;
using Model;


namespace Blazor.Data
{
    public interface IAccountService
    {
        Task<Account> ValidateAccountAsync(string username, string password);

        Task<List<Account>> GetAccountsAsync();
        
        Task Register(Account newAccount, Address newAddress, BankInfo newBankInfo);

        Task storeOrder(int recipeId, string userName, DateTime orderDateTime, IList<OrderedShopIngredients> newShopIngredients,
            int orderId, double orderPrice);
    }
}
