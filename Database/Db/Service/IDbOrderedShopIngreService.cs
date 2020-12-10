using System.Collections.Generic;
using System.Threading.Tasks;
using Database.Model;
using Model;

namespace Db
{
    public interface IDbOrderedShopIngreService
    {
        Task<List<OrderedShopIngredients>> getOrderedShopIngredientsAsync();
        Task<OrderedShopIngredients> getOrderedShopIngredientAsync(int id);
        Task addOrderedShopIngredientAsync(OrderedShopIngredients ingredient);
        Task addOrderedShopIngredientsAsync(IList<OrderedShopIngredients> ingredients, Order order);
        Task updateOrderedShopIngredientAsync(OrderedShopIngredients ingredient);
        Task removeOrderedShopIngredientAsync(OrderedShopIngredients ingredient);
    }
}