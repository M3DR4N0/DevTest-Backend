using DevTestBackend.Contract.Repository;
using DevTestBackend.Entities.Data;
using DevTestBackend.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace DevTestBackend.Repository
{
    public class PerfilRepository : GenericRepository<Perfil>, IPerfilRepository
    {
        public PerfilRepository(DevTestBackendContext context) : base(context) { }

        public async Task<IEnumerable<Perfil>> GetPerfilByClientAsync(int id)
        {
            return await context.Perfils.Where(Perfil => Perfil.ClientId == id).ToListAsync().ConfigureAwait(false);
        }
    }
}