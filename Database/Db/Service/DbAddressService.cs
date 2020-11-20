using System.Threading.Tasks;
using Model;

namespace Db
{
    public class DbAddressService : IDbAddressService
    {
        DatabaseContext ctx = new DatabaseContext();
        
        public async Task saveAddressAsync(Address address)
        {
            ctx.addresses.Add(address);
            await ctx.SaveChangesAsync();
        }

        public async Task updateAddressAsync(Address address)
        {
            ctx.addresses.Update(address);
            ctx.SaveChangesAsync();
        }

        public async Task removeAddressAsync(Address address)
        {
            ctx.addresses.Remove(address);
            ctx.SaveChangesAsync();
        }
    }
}