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

        public RecipeService(){
            so = new SocketsToDatabase();
            recipes = new List<Recipe>();
        }
        
        
        public async Task<IList<Recipe>> getRecipesAsync()
        {
            recipes = (IList<Recipe>) so.getRecipes();
            return recipes;
        }
    }
}