using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Database.Model;
using Model;

namespace Blazor.Data
{
    public interface IOrderService
    {
        Task storeOrder(Order newOrder);
        
        Task<List<Order>> GetOrdersAsync();
    }
}