using System;
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
            List<Shop> temp = await ctx.shops.Include(s => s.shopAddress).Include(s=>s.vares).ToListAsync();
            return temp;
        }

        public async Task<Shop> addShopAsync(Shop shop)
        {
            foreach (var shopExists in ctx.shops)
            {
                if (shopExists.shopId == shop.shopId)
                {
                    return shop;
                }
            }
            Console.WriteLine("Trying to add");
            await ctx.shops.AddAsync(shop);
            await ctx.SaveChangesAsync();
            return shop;
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

        public async Task linkShopVareAsync(int shopId, int shopIngredientId)
        {
            Shop shop1 = await ctx.shops.FirstAsync(s => s.shopId == shopId);
            ShopIngredient shopIngredient1 = await ctx.shopIngredients.FirstAsync(s => s.id == shopIngredientId);
            ShopVare sv2 = new ShopVare()
            {
                shop = shop1,
                shopIngredient = shopIngredient1
            };
            shop1.shopVares = new List<ShopVare>();
            shop1.shopVares.Add(sv2);
            shop1.vares.Add(shopIngredient1);
            ctx.Update(shop1);
            await ctx.SaveChangesAsync();
        }
    }
}