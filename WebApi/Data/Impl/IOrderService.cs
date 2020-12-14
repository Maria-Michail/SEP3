using System.Collections.Generic;
using System.Threading.Tasks;
using Database.Model;
using Model;

namespace WebApi.Data.Impl
{
    public interface IOrderService
    {
        Task AddOrderAsync(Order order);
        
        Task<IList<Order>> GetOrders(string username);
    }
}