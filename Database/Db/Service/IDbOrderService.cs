using System.Collections.Generic;
using System.Threading.Tasks;
using Model;

namespace Db
{
    public interface IDbOrderService
    {
        Task<List<Order>> getOrdersAsync();
        Task<Order> getOrderAsync(int id);
        Task addOrderAsync(Order order);
        Task updateOrderAsync(Order order);
        Task removeOrderAsync(Order order);
    }
}