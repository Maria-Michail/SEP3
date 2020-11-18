using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Database.Model;
using Model;

namespace Db
{
    public class DbService : IDbService
    {
        DatabaseContext ctx = new DatabaseContext();
        
        //Recipies
        public async Task<Ingredient> getIngredientAsync(int id)
        {
            Ingredient temp = await ctx.ExistingIngredients.FirstOrDefaultAsync(i => i.ingredientId == id);
            return temp;
        }

        public async Task<IList<Ingredient>> getIngredientsAsync()
        {
            IList<Ingredient> ingredients = await ctx.ExistingIngredients.ToListAsync();
            return ingredients;
        }

        public async Task<IList<SuperMarket>> getSupermarketsWithIngredientAsync(Ingredient ingredient)
        {
            IList<SuperMarket> superMarkets =
                await ctx.SuperMarkets.Where(s => s.ingredients.Contains(ingredient)).ToListAsync();
            return superMarkets;
        }

        public async Task<IList<Recipe>> getRecipiesWithIngredientAsync(Ingredient ingredient)
        {
            IList<Recipe> recipes = await ctx.Recipes.Where(r => r.ingredients.Contains(ingredient)).ToListAsync();
            return recipes;
        }

        public async Task<int> getIngredientIdAsync(Ingredient ingredient)
        {
            Ingredient temp = await ctx.ExistingIngredients.FirstAsync(i => i.name.Equals(ingredient.name));
            return temp.ingredientId;
        }

        public async Task addIngredientAsync(Ingredient ingredient)
        {
            if (!ctx.ExistingIngredients.Contains(ingredient))
            {
                int id = ctx.ExistingIngredients.Count();
                ingredient.ingredientId = id;
                ctx.ExistingIngredients.Add(ingredient);
                await ctx.SaveChangesAsync();
            }
        }

        public async Task deleteIngredient(Ingredient ingredient)
        {
            if (ctx.ExistingIngredients.Contains(ingredient))
            {
                Ingredient temp = ctx.ExistingIngredients.First(i => i.name.Equals(ingredient.name));
                int id = temp.ingredientId;
                ctx.ExistingIngredients.Remove(ingredient);
                List<Ingredient> listToUpdate = ctx.ExistingIngredients.Where(i => i.ingredientId > id).ToList();
                foreach (var ing in listToUpdate)
                {
                    ing.ingredientId = id;
                    ctx.ExistingIngredients.Update(ing);
                    id++;
                }

                await ctx.SaveChangesAsync();
            }
        }

        public async Task updateIngredient(Ingredient ingredient)
        {
            if (ctx.ExistingIngredients.Contains(ingredient))
            {
                Ingredient temp = ctx.ExistingIngredients.First(i => i.name.Equals(ingredient.name));
                int id = temp.ingredientId;
                temp = ingredient;
                temp.ingredientId = id;
                ctx.ExistingIngredients.Update(temp);
                await ctx.SaveChangesAsync();
            }
        }

        public async Task<List<Recipe>> getRecipiesAsync()
        {
            List<Recipe> temp = await ctx.Recipes.ToListAsync();
            return temp;
        }

        public async Task<Recipe> getRecipeAsync(int id)
        {
            Recipe temp = await ctx.Recipes.FirstOrDefaultAsync(r => r.recipeId == id);
            return temp;
        }

        public async Task<IList<Ingredient>> getRecipeIngredientAsync(int id)
        {
            Recipe temp = await ctx.Recipes.FirstOrDefaultAsync(r => r.recipeId == id);
            IList<Ingredient> ingredients = temp.ingredients;
            return ingredients;
        }

        public async Task addIngredientToRecipy(Ingredient ingredient, int id)
        {
            Recipe temp = await ctx.Recipes.FirstOrDefaultAsync(r => r.recipeId == id);
            if (temp != null && !temp.ingredients.Contains(ingredient))
            {
                if (ctx.ExistingIngredients.Contains(ingredient))
                {
                    Ingredient toBeAdded = ingredient;
                    toBeAdded.ingredientId = await getIngredientIdAsync(ingredient);
                    temp.ingredients.Add(toBeAdded);
                    ctx.Recipes.Update(temp);
                }else {
                    await addIngredientAsync(ingredient);
                    Ingredient toBeAdded = ingredient;
                    toBeAdded.ingredientId = await getIngredientIdAsync(ingredient);
                    temp.ingredients.Add(toBeAdded);
                    ctx.Recipes.Update(temp);
                }
            }
        }

        public async Task deleteRecipeAsync(Recipe recipe)
        {
            ctx.Recipes.Remove(recipe);
            ctx.SaveChangesAsync();
        }

        public async Task updateRecipeAsync(Recipe recipe)
        {
            ctx.Recipes.Update(recipe);
            await ctx.SaveChangesAsync();
        }

        public async Task addRecipeAsync(Recipe recipe)
        {
            ctx.Recipes.Add(recipe);
            ctx.SaveChangesAsync();
        }

        //Supermarkets
        public async Task<List<SuperMarket>> getSuperMarketsAsync()
        {
            List<SuperMarket> temp = await ctx.SuperMarkets.ToListAsync();
            return temp;
        }

        public async Task<SuperMarket> getSuperMarketAsync(int id)
        {
            SuperMarket temp = await ctx.SuperMarkets.FirstOrDefaultAsync(s => s.supermarkedId == id);
            return temp;
        }

        public async Task<IList<Ingredient>> getSuperMarketsVaresAsync(int id)
        {
            SuperMarket temp = await ctx.SuperMarkets.FirstOrDefaultAsync(s => s.supermarkedId == id);
            IList<Ingredient> ingredients = temp.ingredients;
            return ingredients;
        }

        public async Task addIngredientToSuperMarket(Ingredient ingredient, int id)
        {
            SuperMarket temp = await getSuperMarketAsync(id);
            if (ingredient.price == null || ingredient.price < 0 ){
                throw new System.Exception("Price must be set");
            }
            else
            {
                if (!temp.ingredients.Contains(ingredient))
                {
                    temp.ingredients.Add(ingredient);
                    ctx.SuperMarkets.Update(temp);
                    await ctx.SaveChangesAsync();
                }
            }
        }

        public async Task deleteSupermarketAsync(SuperMarket superMarket)
        {
            ctx.SuperMarkets.Remove(superMarket);
            await ctx.SaveChangesAsync();
        }

        public async Task updateSupermarketAsync(SuperMarket superMarket)
        {
            ctx.SuperMarkets.Update(superMarket);
            await ctx.SaveChangesAsync();
        }

        public async Task addSuperMarketAsync(SuperMarket superMarket)
        {
            ctx.SuperMarkets.Add(superMarket);
            await ctx.SaveChangesAsync();
        }

        //Accounts
        public async Task<List<Account>> GetAccountsAcyns()
        {
            List<Account> accounts = await ctx.Accounts.ToListAsync();   
            return accounts;
        }

        public async Task removeAccountAsync(Account account)
        {
            ctx.Remove(account);
            await ctx.SaveChangesAsync();
        }

        public async Task saveAccountAsync(Account account)
        {
           await ctx.Accounts.AddAsync(account);
           await ctx.SaveChangesAsync();
        }

        public async Task updateAccountAsync(Account account)
        {
            ctx.Accounts.Update(account);
            await ctx.SaveChangesAsync();
        }
    }
}