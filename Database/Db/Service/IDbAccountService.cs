using System.Collections.Generic;
using System.Threading.Tasks;
using Database.Model;
using Model;

namespace Db{
    public interface IDbAccountService{
        Task<List<Account>> GetAccountsAcyns();
        
        Task<Account> addAccountAsync(Account account);
        

        Task LinkAddress(Account newaccount, Address newaddress);
        Task LinkBankInfo(Account newaccount, BankInfo newbankInfo);

    }
}