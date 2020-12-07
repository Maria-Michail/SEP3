using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Database.Model;
using System.Text.Json;
using Model;

namespace Blazor.Data
{
    public class RecipeService : IRecipeService
    {
        
        private readonly HttpClient client;
        private string uri = "https://localhost:5001";

        public RecipeService()
        {
            client = new HttpClient();
        }
        public IList<Recipe> Recipes { get; private set; }
        public Recipe recipe { get; set; }

        public async Task<List<Recipe>> GetRecipesAsync()
        {
            Task<string> stringAsync = client.GetStringAsync(uri+"/Recipe");
            string message = await stringAsync;
            Console.WriteLine(message +"--> RecipeService --1");
            List<Recipe> result = JsonSerializer.Deserialize<List<Recipe>>(message);
            Console.WriteLine(result.ToString() +"--> RecipeService --2");
            Recipes = result;
            return result;
        }
    }

}