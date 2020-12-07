using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Database.Model;

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

        public async Task storeOrder(int recipeId, string userName, DateTime orderDateTime, IList<OrderedShopIngredients> newShopIngredients, int orderId,
            double orderPrice)
        {
            Order newOrder = new Order();
            newOrder.recipeId = recipeId;
            newOrder.userName = userName;
            newOrder.dateTime = orderDateTime;
            newOrder.orderedShopIngredientses = newShopIngredients;
            //int max = orders.Max(order => order.orderId);
            //newOrder.orderId = (++max);
            newOrder.orderId = 0;
            newOrder.orderPrice = orderPrice;
            
            string order = JsonSerializer.Serialize(newOrder);
            HttpContent content = new StringContent(order,
                Encoding.UTF8,
                "application/json");
            await client.PostAsync(uri+"/Orders", content);
        }
    }
}