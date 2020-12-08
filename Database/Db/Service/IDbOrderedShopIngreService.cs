using System.Collections.Generic;
using System.Threading.Tasks;
using Database.Model;
using Database.Model.Order;

namespace Db
{
    public interface IDbOrderedShopIngreService
    {
        Task<List<OrderedIngredient>> getOrderedShopIngredientsAsync();
        Task<OrderedIngredient> getOrderedShopIngredientAsync(int id);
        Task addOrderedShopIngredientAsync(OrderedIngredient ingredient);
        Task addOrderedShopIngredientsAsync(IList<OrderedIngredient> ingredient);
        Task updateOrderedShopIngredientAsync(OrderedIngredient ingredient);
        Task removeOrderedShopIngredientAsync(OrderedIngredient ingredient);
    }
}