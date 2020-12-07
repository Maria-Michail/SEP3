using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Model;
using WebApi.Networking;

namespace Blazor.Data
{
    public class IngredientService : IIngredientsService
    {
        ISocketsToDatabase so;
        private IList<Ingredient> ingredients;
        private int recipeId;

        public IngredientService()
        {
            so = new SocketsToDatabase();
            ingredients = new List<Ingredient>();
        }

        

        public async Task<IList<Ingredient>> GetIngredientsAsync()
        {
            ingredients =  (List<Ingredient>) so.getAllIngredients();
            return ingredients;
        }

    }
}