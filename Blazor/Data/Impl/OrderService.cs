using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Blazor.Authorization;
using Database.Model;
using Model;

namespace Blazor.Data
{
    public class OrderService : IOrderService
    {
        private readonly HttpClient client;
        private string uri = "https://localhost:5001";
        public IList<Order> Order { get; private set; }

        public OrderService()
        {
            client = new HttpClient();
        }

        public async Task storeOrder(Order newOrder)
        {
            if (newOrder.OrderedShopIngredients == null || newOrder.OrderedShopIngredients.Count == 0)
            {
                Console.WriteLine("no order");
            }
            else
            {
                string order = JsonSerializer.Serialize(newOrder);
                Console.WriteLine(order);
                HttpContent content = new StringContent(order,
                    Encoding.UTF8,
                    "application/json");
                Console.WriteLine("sp");
                await client.PostAsync(uri+"/Order", content);
            }
        }

        public async Task<List<Order>> GetOrdersAsync()
        {
            string username = CustomAuthenticationStateProvider.getUser().username;
            Task<string> stringAsync = client.GetStringAsync($"https://localhost:5001/Order/k/{username}");
            string message = await stringAsync;
            Console.WriteLine(message +"--> OrderService --1");
            List<Order> result = JsonSerializer.Deserialize<List<Order>>(message);
            Console.WriteLine(result.ToString() +"--> OrderService --2");
            Order = result;
            Console.WriteLine(result.ToString() +"resultPrint");
            return result;
        }
    }
}