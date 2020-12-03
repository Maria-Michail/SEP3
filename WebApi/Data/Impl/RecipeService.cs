using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Database.Model;
using Microsoft.AspNetCore.Mvc;
using Model;
using WebApi.Networking;

namespace Data.Impl
{
    public class RecipeService : IRecipeService
    {
        
        SocketsToDatabase so;
        private IList<Recipe> recipes;
        private IList<Ingredient> ingredients;

        public RecipeService(){
            so = new SocketsToDatabase();
            recipes = new List<Recipe>();
            ingredients = new List<Ingredient>();
        }
        
        
        public async Task<IList<Recipe>> getRecipesAsync()
        {
            recipes = (IList<Recipe>) so.getRecipes();
            Console.WriteLine(recipes.ToString() + "--> WebApi/Data/Impl/RecipeService.cs");
            return recipes;
        }
        
        public async Task<IList<Ingredient>> GetIngredientsAsync(int id)
        {
            ingredients =  (List<Ingredient>) so.getIngredients(id);
            return ingredients;
        }
    }
}