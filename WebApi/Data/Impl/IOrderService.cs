using System.Collections.Generic;
using System.Threading.Tasks;
using Database.Model;
using Model;

namespace WebApi.Data.Impl
{
    public interface IOrderService
    {
        Task<Order> AddOrderAsync(Order order);
    }
}