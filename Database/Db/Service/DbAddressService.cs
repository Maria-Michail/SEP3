using System.Collections.Generic;
using System.Threading.Tasks;
using Database.Model;
using Microsoft.EntityFrameworkCore;
using Model;

namespace Db
{
    public class DbAddressService : IDbAddressService
    {
        DatabaseContext ctx = new DatabaseContext();
        public async Task<List<Address>> GetAddressesAcyns()
        {
            List<Address> addresses = await ctx.addresses.ToListAsync();   
            return addresses;
        }
        
        public async Task<Address> saveAddressAsync(Address address)
        {
            foreach (var addressExists in ctx.addresses)
            {
                if (addressExists.street.Equals(address.street))
                {
                    return address;
                }
            }
            ctx.addresses.Add(address);
            await ctx.SaveChangesAsync();
            return address;
        }

        
    }
}