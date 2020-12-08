using System;
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
        public async Task<Recipe> getRecipeByIdAsync(int recipeid)
        {
            Recipe temp = await ctx.recipes.FirstOrDefaultAsync(r => r.recipeId == recipeid);
            return temp;
        }

        public async Task removeRecipeAsync(string recipeName)
        {
            ctx.recipes.Remove(await ctx.recipes.FirstAsync(r => r.recipeName.Equals(recipeName)));
            await ctx.SaveChangesAsync();
        }

        public async Task addRecipeAsync(Recipe recipe)
        {
            bool boolRecipeExists = false;
            foreach (var recipeExists in ctx.recipes)
            {
                if (recipeExists.recipeId == recipe.recipeId)
                {
                    boolRecipeExists = true;
                }
            }

            if (!boolRecipeExists)
            {
                ctx.recipes.Add(recipe);
            }
            await ctx.SaveChangesAsync();
        }
        public async Task LinkIngredient(Recipe recipe, Ingredient ingredient)
        {
            Recipe recipe1 = await ctx.recipes.FirstAsync(s => s.recipeId == recipe.recipeId );
            Ingredient ing1 = await ctx.ingredients.FirstAsync(c => c.ingredientId == ingredient.ingredientId);
            IngredientRecipe sc = new IngredientRecipe()
            {
                recipe = recipe1,
                ingredient = ing1
            };
            if (recipe1.IngredientRecipes == null)
            {
                recipe1.IngredientRecipes = new List<IngredientRecipe>();
            }
            recipe1.IngredientRecipes.Add(sc);
            ctx.Update(recipe1);
            await ctx.SaveChangesAsync();
        }
        
        public async Task LinkCategory(Recipe recipe, Category category)
        {
            Recipe recipe1 = await ctx.recipes.FirstAsync(s => s.recipeId == recipe.recipeId );
            Category cat1 = await ctx.categories.FirstAsync(c => c.categoryName.Equals(category.categoryName));
            RecipeCategory sc = new RecipeCategory()
            {
                recipe = recipe1,
                category = cat1
            };
            if (recipe1.RecipeCategories == null)
            {
                recipe1.RecipeCategories = new List<RecipeCategory>();
            }
            recipe1.RecipeCategories.Add(sc);
            ctx.Update(recipe1);
            await ctx.SaveChangesAsync();
        }

        public async Task updateRecipeAsync(Recipe recipe)
        {
            ctx.recipes.Update(recipe);
            await ctx.SaveChangesAsync();
        }
    }
}