using System.Collections.Generic;
using System.Threading.Tasks;
using Database.Model;
using Microsoft.EntityFrameworkCore;
using Model;

namespace Db
{
    public class DbShopService:IDbShopService
    {
        DatabaseContext ctx = new DatabaseContext();

        //Accounts
        public async Task<List<Shop>> GetShopsAcyns()
        {
            List<Shop> shops = await ctx.shops.ToListAsync();  
            return shops;
        }

        public async Task removeShopAsync(Shop shop)
        {
            ctx.shops.Remove(shop);
            await ctx.SaveChangesAsync();
        }

        public async Task addShopAsync(Shop shop)
        {
            bool boolShopExists = false;
            foreach (var shopExists in ctx.shops)
            {
                if (shopExists.shopId==shop.shopId)
                {
                    boolShopExists = true;
                }
            }

            if (!boolShopExists)
            {
                await ctx.shops.AddAsync(shop);
            }
            await ctx.SaveChangesAsync();
        }

        public async Task updateShopAsync(Shop shop)
        {
            ctx.shops.Update(shop);
            await ctx.SaveChangesAsync();
        }
    }
}