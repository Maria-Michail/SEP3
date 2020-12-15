using System.Collections.Generic;
using System.Threading.Tasks;
using Model;

namespace Db
{
    public interface IDbShopIngrService
    {
        Task<List<ShopIngredient>> getShopIngredientsAsync();
        Task addShopIngredientAsync(ShopIngredient ingredient,Shop shop);
        Task updateShopIngredientAsync(ShopIngredient ingredient);
        Task removeShopIngredientAsync(ShopIngredient ingredient);
    }
}