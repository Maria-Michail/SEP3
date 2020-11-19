using System.Collections.Generic;
using System.Threading.Tasks;
using Database.Model;
using Model;

namespace Db{
    public interface IDbService
    {
        //Account Calls
        Task<List<Account>> GetAccountsAcyns();

        Task saveAccountAsync(Account account);

        Task removeAccountAsync(Account account);

        Task updateAccountAsync(Account account);
    }
}