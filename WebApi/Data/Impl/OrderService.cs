using System;
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
        private IList<Order> orders;

        public OrderService()
        {
            so = new SocketsToDatabase();
            orders = new List<Order>();
        }


        public async Task AddOrderAsync(Order order)
        {
            so.AddOrder(order);
        }

        public async Task<IList<Order>> GetOrders(string username)
        {
            orders = (List<Order>) so.getOrders(username);
           Console.WriteLine(orders.ToString() +"orderService");
           return orders;
        }
    }
}