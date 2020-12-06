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

        public async Task<ShopIngredient> getShopIngredientAsync(int id)
        {
            ShopIngredient temp = await ctx.shopIngredients.FirstOrDefaultAsync(s => s.id == id);
            return temp;
        }

        public async Task addShopIngredientAsync(ShopIngredient ingredient)
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
        }
        
        public async Task LinkShop(ShopIngredient shopIngredient, Shop shop)
        {
            ShopIngredient shoping1 = await ctx.shopIngredients.FirstAsync(s => s.id == shopIngredient.id );
            Shop shop1 = await ctx.shops.FirstAsync(c => c.shopId == shop.shopId);
            ShopVare sc2 = new ShopVare()
            {
                shop = shop1,
                shopIngredient = shoping1
            };
            if (shop1.shopVares == null)
            {
                shop1.shopVares = new List<ShopVare>();
            }
            shop1.shopVares.Add(sc2);
            ctx.Update(shop1);
            await ctx.SaveChangesAsync();
        }

        public async Task updateShopIngredientAsync(ShopIngredient ingredient)
        {
            ctx.shopIngredients.Update(ingredient);
            await ctx.SaveChangesAsync();
        }

        public async Task removeShopIngredientAsync(ShopIngredient ingredient)
        {
            ctx.shopIngredients.Remove(ingredient);
            await ctx.SaveChangesAsync();
        }
    }
}