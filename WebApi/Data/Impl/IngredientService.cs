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
        SocketsToDatabase so;
        private IList<Ingredient> ingredients;
        private int recipeId;

        public IngredientService()
        {
            so = new SocketsToDatabase();
            ingredients = new List<Ingredient>();
        }

        public async Task<IList<Ingredient>> GetIngredientsAsync(int id)
        {
            recipeId = id;
            ingredients =  (List<Ingredient>) so.getIngredients(id);
            return ingredients;
        }

        public async Task<IList<Ingredient>> GetAllIngredientsAsync()
        {
            //recipeId is 0 even though it was assigned to one in httppost
            ingredients = (List<Ingredient>) so.getIngredients(recipeId);
            return ingredients;
        }
    }
}