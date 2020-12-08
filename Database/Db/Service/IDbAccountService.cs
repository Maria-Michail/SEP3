using System.Collections.Generic;
using System.Threading.Tasks;
using Database.Model;
using Model;

namespace Db{
    public interface IDbAccountService{
        Task<List<Account>> GetAccountsAcyns();
        
        Task<Account> addAccountAsync(Account account);
        Task<Account> GetAccountAcyns(string username);

        Task removeAccountAsync(Account account);

        Task updateAccountAsync(Account account);

        Task LinkAddress(Account newaccount, Address newaddress);
        Task LinkBankInfo(Account newaccount, BankInfo newbankInfo);

        //Task<Account> ValidateUser(string username, string password);
    }
}