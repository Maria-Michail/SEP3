using System.Collections.Generic;
using System.Threading.Tasks;
using Model;

namespace Db
{
    public interface IDbShopService
    {
        Task<List<Shop>> GetShopsAcyns();
        
        Task addShopAsync(Shop shop);


        Task removeShopAsync(Shop shop);

        Task updateShopAsync(Shop shop);
    }
}