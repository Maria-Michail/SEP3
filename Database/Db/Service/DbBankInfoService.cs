using System.Collections.Generic;
using System.Threading.Tasks;
using Database.Model;
using Microsoft.EntityFrameworkCore;

namespace Db
{
    public class DbBankInfoService : IDbBankInfoService
    {
        DatabaseContext ctx = new DatabaseContext();

        //Accounts
        public async Task<List<BankInfo>> GetBankInfosAcyns()
        {
            List<BankInfo> bankInfos = await ctx.bankInfos.ToListAsync();   
            return bankInfos;
        }

        public async Task removeBankInfoAsync(BankInfo bankInfo)
        {
            ctx.bankInfos.Remove(bankInfo);
            await ctx.SaveChangesAsync();
        }

        public async Task<BankInfo> addBankInfoAsync(BankInfo bankInfo)
        {
            await ctx.bankInfos.AddAsync(bankInfo);
            await ctx.SaveChangesAsync();
            return bankInfo;
        }

        public async Task updateBankInfoAsync(BankInfo bankInfo)
        {
            ctx.bankInfos.Update(bankInfo);
            await ctx.SaveChangesAsync();
        }
        
    }
}