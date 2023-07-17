using DevTestBackend.Entities.Models;

namespace DevTestBackend.Contract.Repository
{
    public interface IClientRepository : IGenericRepository<Client>
    {
        Task<bool> ExistAsync(int id);
        Task BulkDeleteAsync(int id);
    } 
}
