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

        public async Task<bool> ExistAsync(int id)
        {
            return await context.Clients.AnyAsync(Client => Client.ClientId == id).ConfigureAwait(false);
        }      
    }
}