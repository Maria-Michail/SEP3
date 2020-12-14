using System.Collections.Generic;
using System.Threading.Tasks;
using Database.Model;
using Model;

namespace Db
{
    public interface IDbOrderedShopIngreService
    {
        Task addOrderedShopIngredientsAsync(IList<OrderedShopIngredients> ingredients, Order order);
    }
}