using DevTestBackend.Contract.Repository;
using DevTestBackend.Entities.Data;
using DevTestBackend.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace DevTestBackend.Repository
{
    public class AddressRepository : GenericRepository<Address>, IAddressRepository
    {
        
        public AddressRepository(DevTestBackendContext context) : base(context) 
        { 
        }

        public async Task<bool> ExistAsync(int id)
        {
            return await context.Addresses.AnyAsync(address => address.AddressId == id).ConfigureAwait(false);
        }

        public async Task<IEnumerable<Address>> GetAddressByClientAsync(int id)
        {
            return await context.Addresses.Where(address => address.ClientId == id).ToListAsync().ConfigureAwait(false);
        }
    }
}