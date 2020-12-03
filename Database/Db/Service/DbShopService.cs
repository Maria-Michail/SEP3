using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Model;

namespace Db
{
    public class DbShopService : IDbShopService
    {
        DatabaseContext ctx = new DatabaseContext();
        public async Task<List<Shop>> getShopsAsync()
        {
            List<Shop> temp = await ctx.shops.ToListAsync();
            return temp;
        }

        public async Task addShopAsync(Shop shop)
        {
            if (!ctx.shops.Contains(shop))
            {
                await ctx.shops.AddAsync(shop);
                await ctx.SaveChangesAsync();
            }
        }

        public async Task updateShopAsync(Shop shop)
        {
            
        }

        public async Task removeShopAsync(string shopName)
        {
            Shop toDelete = await ctx.shops.FirstOrDefaultAsync(s => s.shopName.Equals(shopName));
            if (toDelete != null)
            {
                ctx.shops.Remove(toDelete);
                ctx.SaveChangesAsync();
            }
        }
    }
}