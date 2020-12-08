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
            List<Recipe> recipes = await ctx.recipes.Include(r => r.Category).ToListAsync();
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
            if (recipe.ingredients.Count > 0)
            {
                foreach (var ingr in recipe.ingredients)
                {
                    if (!ctx.ingredients.Contains(ingr))
                    {
                        ctx.ingredients.Add(ingr);
                    }
                }
            }

            if (!ctx.categories.Contains(recipe.Category))
            {
                ctx.categories.Add(recipe.Category);
            }

            String categoryName = recipe.Category.categoryName;
            linkCategoryAsync(recipe.recipeName, categoryName);
            IList<Ingredient> ingredients = recipe.ingredients;
            recipe.ingredients = new List<Ingredient>();
            await ctx.recipes.AddAsync(recipe);
            await ctx.SaveChangesAsync();
            foreach (var ingredient in ingredients)
            {
                linkIngredientAsync(recipe.recipeName, ingredient.ingredientId);
            }
        }

        public async Task updateRecipeAsync(Recipe recipe)
        {
            ctx.recipes.Update(recipe);
            await ctx.SaveChangesAsync();
        }

        public async Task linkIngredientAsync(string name, int ingredientId)
        {
            Recipe temp1 = await ctx.recipes.FirstAsync(r => r.recipeName.Equals(name));
            Ingredient temp2 = await ctx.ingredients.FirstAsync(i => i.ingredientId == ingredientId);
            IngredientRecipe ir3 = new IngredientRecipe()
            {
                ingredient = temp2,
                recipe = temp1
            };
            if (temp1.IngredientRecipes != null)
            {
                temp1.IngredientRecipes.Add(ir3);
            }
            else
            {
                temp1.IngredientRecipes = new List<IngredientRecipe>();
                temp1.IngredientRecipes.Add(ir3);
            }
            temp1.ingredients.Add(temp2);
            ctx.Update(temp1);
            await ctx.SaveChangesAsync();
        }

        public async Task linkCategoryAsync(string name, string categoryName)
        {
            Recipe temp1 = await ctx.recipes.FirstAsync(c => c.recipeName.Equals(name));
            Category temp2 = await ctx.categories.FirstAsync(c => c.categoryName.Equals(categoryName));
            RecipeCategory rc3 = new RecipeCategory()
            {
                category = temp2,
                recipe = temp1
            };
            temp1.RecipeCategories = new List<RecipeCategory>();
            temp1.RecipeCategories.Add(rc3);
            temp1.Category = temp2;
            ctx.Update(temp1);
            await ctx.SaveChangesAsync();
        }
    }
}