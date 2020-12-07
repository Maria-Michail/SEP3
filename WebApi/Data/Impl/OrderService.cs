using System.Collections.Generic;
using System.Threading.Tasks;
using Database.Model;
using WebApi.Networking;

namespace WebApi.Data.Impl
{
    public class OrderService : IOrderService
    {
        private SocketsToDatabase so;
        private IList<OrderedShopIngredients> orderedShopIngredientses;

        public OrderService()
        {
            so = new SocketsToDatabase();
            orderedShopIngredientses = new List<OrderedShopIngredients>();
        }


        public async Task<Order> AddOrderAsync(Order order)
        {
            Order addedOrder = (Order)so.AddOrder(order);
            return addedOrder;
        }

       
    }
}