using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Model;

namespace Db
{
    public class DbShopIngreService : IDbShopIngrService
    {
        DatabaseContext ctx = new DatabaseContext();
        public async Task<List<ShopIngredient>> getShopIngredientsAsync()
        {
            List<ShopIngredient> temp = await ctx.shopIngredients.ToListAsync();
            return temp;
        }

        /*public async Task<ShopIngredient> getShopIngredientAsync(int id)
        {
            ShopIngredient temp = await ctx.shopIngredients.FirstOrDefaultAsync(s => s.id == id);
            return temp;
        }*/
        

        public async Task addShopIngredientAsync(ShopIngredient ingredient, Shop shop)
        {
            bool boolShopIngExists = false;
            foreach (var shopIngExists in ctx.shopIngredients)
            {
                if (shopIngExists.id == ingredient.id)
                {
                    boolShopIngExists = true;
                }
            }

            if (!boolShopIngExists)
            {
                ctx.shopIngredients.Add(ingredient);
            }
            await ctx.SaveChangesAsync();

            ShopIngredient getSI = ctx.shopIngredients.FirstOrDefault(n => n.name.Equals(ingredient.name));
            Shop getS = ctx.shops.FirstOrDefault(s => s.shopName.Equals(shop.shopName));
            await linkShopVareAsync(getS.shopId, getSI.id);
        }
        
        public async Task linkShopVareAsync(int shopId, int shopIngredientId)
        {
            Shop shop1 = await ctx.shops.FirstAsync(s => s.shopId == shopId);
            /*foreach (var vare in ctx.shopvares.ToList())
            {
                if (shopId == vare.shopId)
                {
                    shop1.shopVares.Add(vare);
                }
            }*/
            ShopIngredient shopIngredient1 = await ctx.shopIngredients.FirstAsync(s => s.id == shopIngredientId);
            ShopVare sv2 = new ShopVare()
            {
                shop = shop1,
                shopIngredient = shopIngredient1
            };
            if (shop1.shopVares == null)
            {
                shop1.shopVares = new List<ShopVare>();
            }
            shop1.shopVares.Add(sv2);
            await ctx.SaveChangesAsync();
        }
        

        public async Task updateShopIngredientAsync(ShopIngredient ingredient)
        {
            ctx.shopIngredients.Update(ingredient);
            await ctx.SaveChangesAsync();
        }

        public async Task removeShopIngredientAsync(ShopIngredient ingredient)
        {
            Console.WriteLine("Inside remove");
            if (ctx.shopvares.FirstOrDefaultAsync(s => s.shopIngredientId == ingredient.id) != null)
            {
                Console.WriteLine("ShopVares to remove");
                List<ShopVare> shopVares = await ctx.shopvares.Where(s => s.shopIngredientId == ingredient.id).ToListAsync();
                foreach (var shopVare in shopVares)
                {
                    Shop temp = await ctx.shops.FirstOrDefaultAsync(s=> s.shopId == shopVare.shopId);
                    Console.WriteLine(temp);
                    temp.vares.Remove(ingredient);
                    temp.shopVares.Remove(shopVare);
                    ctx.shops.Update(temp);
                    ingredient.ShopVares.Remove(shopVare);
                    ctx.shopvares.Remove(shopVare);
                }
            }
            ctx.shopIngredients.Remove(ingredient);
            await ctx.SaveChangesAsync();
        }
    }
}