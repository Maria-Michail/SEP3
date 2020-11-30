using System.Collections.Generic;
using System.Threading.Tasks;
using Database.Model;

namespace Db
{
    public interface IDbBankInfoService
    {
        Task<List<BankInfo>> GetBankInfosAcyns();
        
        Task<BankInfo> addBankInfoAsync(BankInfo bankInfo);


        Task removeBankInfoAsync(BankInfo bankInfo);

        Task updateBankInfoAsync(BankInfo bankInfo);
    }
}