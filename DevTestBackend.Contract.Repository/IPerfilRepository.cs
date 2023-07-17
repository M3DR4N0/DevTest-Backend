using DevTestBackend.Entities.Models;

namespace DevTestBackend.Contract.Repository
{
    public interface IPerfilRepository : IGenericRepository<Perfil>
    {
        Task<IEnumerable<Perfil>> GetPerfilByClientAsync(int id);
    }
}
