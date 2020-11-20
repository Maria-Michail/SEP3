using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Model;

namespace Db
{
    public class DbIngredientService : IDbIngredientService
    {
        DatabaseContext ctx = new DatabaseContext();
        
        public async Task<List<Ingredient>> getIngredientsAsync()
        {
            List<Ingredient> temp = await ctx.ingredients.ToListAsync();
            return temp;
        }

        public async Task<Ingredient> getIngredientAsync(string name)
        {
            Ingredient temp = await ctx.ingredients.FirstOrDefaultAsync(i => i.name.Equals(name));
            return temp;
        }

        public async Task addIngredientAsync(Ingredient ingredient)
        {
            ctx.ingredients.Add(ingredient);
            await ctx.SaveChangesAsync();
        }

        public async Task updateIngredientAsync(Ingredient ingredient)
        {
            ctx.ingredients.Update(ingredient);
            await ctx.SaveChangesAsync();
        }

        public async Task removeIngredientAsync(Ingredient ingredient)
        {
            ctx.ingredients.Remove(ingredient);
            await ctx.SaveChangesAsync();
        }
    }
}