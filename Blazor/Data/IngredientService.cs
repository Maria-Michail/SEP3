using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Database.Model;
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
        
        
        public async Task<List<Ingredient>> GetIngredientsAsync(int id)
        {
            Console.WriteLine("the username is valid " + id);
            string userAsJson = await client.GetStringAsync($"https://localhost:5001/Recipe/ing/{id}");
            Console.WriteLine(userAsJson +"--> IngredientService --1");
            List<Ingredient> resultAccount = JsonSerializer.Deserialize<List<Ingredient>>(userAsJson);
            Console.WriteLine(resultAccount[0].ingredientName +"--> IngredientService --2");
            Ingredients = resultAccount;
            return resultAccount;
           
        }
        
        /*public async Task<IList<Ingredient>> GetIngredientsAsync() {
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
        }*/
    }
}