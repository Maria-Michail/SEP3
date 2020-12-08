using System.Collections.Generic;
using System.Threading.Tasks;
using Database.Model;
using Model;
using WebApi.Networking;

namespace WebApi.Data.Impl
{
    public class OrderService : IOrderService
    {
        private ISocketsToDatabase so;

        public OrderService()
        {
            so = new SocketsToDatabase();
        }


        public async Task<Order> AddOrderAsync(Order order)
        {
            Order addedOrder = (Order)so.AddOrder(order);
            return addedOrder;
        }

       
    }
}