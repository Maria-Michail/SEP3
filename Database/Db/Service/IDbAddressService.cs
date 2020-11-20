using System.Threading.Tasks;
using Model;

namespace Db
{
    public interface IDbAddressService
    {
        Task saveAddressAsync(Address address);
        Task updateAddressAsync(Address address);
        Task removeAddressAsync(Address address);
    }
}