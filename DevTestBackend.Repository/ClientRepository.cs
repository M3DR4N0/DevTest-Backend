using DevTestBackend.Contract.Repository;
using DevTestBackend.Entities.Data;
using DevTestBackend.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace DevTestBackend.Repository
{
    public class ClientRepository : GenericRepository<Client>, IClientRepository
    {
        
        public ClientRepository(DevTestBackendContext context) : base(context) 
        { 
        }

        public async Task BulkDeleteAsync(int id)
        {
            await context.Perfils.Where(x => x.ClientId == id).ForEachAsync(x =>
            {
                context.Perfils.Remove(x);
            }).ConfigureAwait(false);

            await context.Addresses.Where(x => x.ClientId == id).ForEachAsync(x =>
            {
                context.Addresses.Remove(x);
            }).ConfigureAwait(false);
        }

        public async Task<bool> ExistAsync(int id)
        {
            return await context.Clients.AnyAsync(Client => Client.ClientId == id).ConfigureAwait(false);
        }      
    }
}