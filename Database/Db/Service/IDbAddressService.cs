using System.Collections.Generic;
using System.Threading.Tasks;
using Database.Model;
using Model;

namespace Db
{
    public interface IDbAddressService
    {
        Task<List<Address>> GetAddressesAcyns();
        Task<Address> saveAddressAsync(Address address);
        Task updateAddressAsync(Address address);
        Task removeAddressAsync(Address address);
    }
}