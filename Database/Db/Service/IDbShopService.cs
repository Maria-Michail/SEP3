using System.Collections.Generic;
using System.Threading.Tasks;
using Model;

namespace Db
{
    public interface IDbShopService
    {
        Task<List<Shop>> getShopsAsync();

        Task<List<ShopVare>> getShopVaresAsync();
        Task<Shop> addShopAsync(Shop shop);
        Task updateShopAsync(Shop shop);
        Task removeShopAsync(string shopName);
        Task linkShopVareAsync(int shopId, int shopIngredientId);
    }
}