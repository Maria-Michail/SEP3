using System.Collections.Generic;
using System.Threading.Tasks;
using Database.Model.Order;
using Model;

namespace Db
{
    public interface IDbOrderService
    {
        Task<List<OrderTable>> getOrdersAsync();
        Task<OrderTable> getOrderAsync(int id);
        Task addOrderAsync(OrderTable order);
        Task updateOrderAsync(OrderTable order);
        Task removeOrderAsync(OrderTable order);
    }
}