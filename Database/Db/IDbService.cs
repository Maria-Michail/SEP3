using System.Collections.Generic;
using System.Threading.Tasks;
using Database.Model;

namespace Db{
    public interface IDbService{
        Task<List<Account>> GetAccountsAcyns();
        
        Task<Account> Register(Account account);


        Task removeAccountAsync(Account account);

        Task updateAccountAsync(Account account);
        
        //Task<Account> ValidateUser(string username, string password);
    }
}