using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Blazor.Authorization;
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
        public IList<OrderedShopIngredients> OrderedShopIngredients { get; private set; }
        private int recipeId { get; set; }


        public void UpdateOrderedShopIngredients(OrderedShopIngredients orderedShopIngredients)
        {
            for (int i=0; i<OrderedShopIngredients.Count ;i++)
            {
                if (OrderedShopIngredients[i].shopIngredient.id == orderedShopIngredients.shopIngredient.id)
                {
                    OrderedShopIngredients[i].uncheck = orderedShopIngredients.uncheck;
                }
            }
        }

        public async Task<List<Ingredient>> GetIngredientsAsync(int id)
        {
            recipeId = id;
            string userAsJson = await client.GetStringAsync($"https://localhost:5001/Recipe/ing/{id}");
            List<Ingredient> resultAccount = JsonSerializer.Deserialize<List<Ingredient>>(userAsJson);
            Ingredients = resultAccount;
            return resultAccount;
        }

        public async Task<List<OrderedShopIngredients>> GetShopIngredientsAsync()
        {
            string userAsJson = await client.GetStringAsync($"https://localhost:5001/Recipe/shoping/{recipeId}");
            Console.WriteLine(userAsJson);
            List<OrderedShopIngredients> resultAccount = JsonSerializer.Deserialize<List<OrderedShopIngredients>>(userAsJson);
            
            OrderedShopIngredients = resultAccount;
            return resultAccount;
        }
        
        
        
    }
}