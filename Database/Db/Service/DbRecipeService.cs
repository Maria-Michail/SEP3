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
            List<Recipe> recipes = await ctx.recipes.Include(r => r.category).ToListAsync();
            return recipes;
        }


        public async Task removeRecipeAsync(string recipeName)
        {
            ctx.recipes.Remove(await ctx.recipes.FirstAsync(r => r.recipeName.Equals(recipeName)));
            await ctx.SaveChangesAsync();
        }

        public async Task addRecipeAsync(Recipe recipe, string categoryName2)
        {
            IList<Ingredient> ingredients = recipe.ingredients;
            Console.WriteLine(ingredients.Count);
            if (ingredients.Count > 0)
            {
                foreach (var ingr in recipe.ingredients)
                {
                    ingr.ingredientId = 0;
                    Console.WriteLine(ingr.ingredientName + ingr.ingredientId);
                    await ctx.ingredients.AddAsync(ingr);
                }
            }
            
            await ctx.SaveChangesAsync();

            Recipe recipe1 = recipe;
            recipe1.category = null;
            recipe1.ingredients = null;
            await ctx.recipes.AddAsync(recipe);
            await ctx.SaveChangesAsync();

            //Category category = ctx.categories.FirstOrDefault(c => c.categoryName.Equals(categoryName2));
            //String categoryName = category.categoryName;
            await linkCategoryAsync(recipe.recipeName, categoryName2);
            
            foreach (var ingredient in ingredients)
            {
                await linkIngredientAsync(recipe.recipeName, ingredient.ingredientId);
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
            if (temp1.IngredientRecipes == null)
            {
                temp1.IngredientRecipes = new List<IngredientRecipe>();
            }
            temp1.IngredientRecipes.Add(ir3);
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
            if (temp1.RecipeCategories == null)
            {
                temp1.RecipeCategories = new List<RecipeCategory>();
            }
            temp1.RecipeCategories.Add(rc3);
            ctx.Update(temp1);
            await ctx.SaveChangesAsync();
            temp1.category = temp2;
            ctx.Update(temp1);
            await ctx.SaveChangesAsync();
        }

        public async Task<List<Category>> getCategoriesAsync()
        {
            List<Category> temp = await ctx.categories.ToListAsync();
            return temp;
        }
    }
}