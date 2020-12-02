using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Model;

namespace Blazor.Data
{
    public class IngredientService : IIngredientsService
    {
        private readonly HttpClient client;
        private string uri = "https://localhost:5001";

        public IngredientService()
        {
            client = new HttpClient();
        }

        public IList<Ingredient> Recipes { get; }
        
        
        public async Task<List<Ingredient>> GetIngredientsAsync()
        {
            Task<string> stringAsync = client.GetStringAsync(uri+"/Ingredient");
            string message = await stringAsync;
            Console.WriteLine(message +"--> IngredientService --1");
            List<Ingredient> result = JsonSerializer.Deserialize<List<Ingredient>>(message);
            Console.WriteLine(result.ToString() +"--> IngredientService --2");
            return result;
        }
    }
}