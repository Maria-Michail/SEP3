using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Database.Model;
using Model;

namespace Blazor.Data
{
    public class OrderService : IOrderService
    {
        private readonly HttpClient client;
        private string uri = "https://localhost:5001";

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
    }
}