using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Db;
using Microsoft.EntityFrameworkCore;
using Model;

namespace Db
{
    public class DbRecipeService : IDbRecipeService
    {
        DatabaseContext ctx = new DatabaseContext();
        
        public async Task<List<Recipe>> getRecipiesAsync()
        {
            List<Recipe> recipes = await ctx.recipes.ToListAsync();
            return recipes;
        }

        public async Task<Recipe> getRecipeAsync(string recipeName)
        {
            Recipe temp = await ctx.recipes.FirstOrDefaultAsync(r => r.recipeName.Equals(recipeName));
            return temp;
        }

        public async Task removeRecipeAsync(string recipeName)
        {
            ctx.recipes.Remove(await ctx.recipes.FirstAsync(r => r.recipeName.Equals(recipeName)));
            await ctx.SaveChangesAsync();
        }

        public async Task addRecipeAsync(Recipe recipe)
        {
            await ctx.recipes.AddAsync(recipe);
            foreach (var ingr in recipe.ingredients)
            {
                if (!ctx.ingredients.Contains(ingr))
                {
                    ctx.ingredients.Add(ingr);
                }
            }
            await ctx.SaveChangesAsync();
        }

        public async Task updateRecipeAsync(Recipe recipe)
        {
            ctx.recipes.Update(recipe);
            await ctx.SaveChangesAsync();
        }
    }
}