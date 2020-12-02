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

        public IngredientService()
        {
            so = new SocketsToDatabase();
            ingredients = new List<Ingredient>();
        }

        public async Task<IList<Ingredient>> GetIngredientsAsync(int id)
        {
            ingredients = (List<Ingredient>) so.getIngredients(id);
            return ingredients;
        }


    }
}