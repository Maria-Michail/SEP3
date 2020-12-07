using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Database.Model;

namespace Blazor.Data
{
    public interface IOrderService
    {
        Task storeOrder(int recipeId, string userName, DateTime orderDateTime, IList<OrderedShopIngredients> newShopIngredients,
            int orderId, double orderPrice);
    }
}