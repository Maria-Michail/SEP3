using System.Collections.Generic;
using System.Linq;
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

       

        public async Task addIngredientAsync(Ingredient ingredient)
        {
            bool boolIngrExists = false;
            foreach (var ingredientExist in ctx.ingredients)
            {
                if (ingredientExist.ingredientId == ingredient.ingredientId)
                {
                    boolIngrExists = true;
                }
            }

            if (!boolIngrExists)
            {
                ctx.ingredients.Add(ingredient);
            }
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

        public async Task<List<Ingredient>> getIngredientsOfRecipeAsync(int recipeId)
        {
            List<Ingredient> ingredients = await ctx.recipes
                .Where(s => s.recipeId == recipeId)
                .SelectMany(i => i.IngredientRecipes)
                .Select(d => d.ingredient)
                .ToListAsync();
            return ingredients;
        }
    }
}