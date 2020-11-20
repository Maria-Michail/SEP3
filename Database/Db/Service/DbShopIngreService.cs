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
            ctx.shopIngredients.Add(ingredient);
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