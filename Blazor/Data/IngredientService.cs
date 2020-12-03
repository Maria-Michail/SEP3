using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
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

        public IList<Ingredient> Ingredients { get; private set;}
        
        
        //public async Task<List<Ingredient>> GetIngredientsAsync(int id)
        //{
        //    Task<string> stringAsync = client.GetStringAsync($"https://localhost:5001/Recipes?recipeId={id}");
        //    string message = await stringAsync;
        //    Console.WriteLine(message +"--> IngredientService --1");
        //    List<Ingredient> result = JsonSerializer.Deserialize<List<Ingredient>>(message);
        //    Console.WriteLine(result.ToString() +"--> IngredientService --2");
        //    Ingredients = result;
        //    return result;
        //}
        
        public async Task<IList<Ingredient>> GetIngredientsAsync() {
            Task<string> stringAsync = client.GetStringAsync(uri+"/Ingredient");
            string message = await stringAsync;
            List<Ingredient> result = JsonSerializer.Deserialize<List<Ingredient>>(message);
            Console.WriteLine(result[0].ingredientName);
            Ingredients = result;
            return result;
        }
        public async Task AddIngredientsAsync(int id) {
            string todoAsJson = JsonSerializer.Serialize(id);
            HttpContent content = new StringContent(todoAsJson,
                Encoding.UTF8,
                "application/json");
            await client.PostAsync(uri+"/Ingredient", content);
        }
    }
}