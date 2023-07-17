using DevTestBackend.Entities.Models;

namespace DevTestBackend.Contract.Repository
{
    public interface IAddressRepository : IGenericRepository<Address>
    {
        Task<bool> ExistAsync(int id);
        Task<IEnumerable<Address>> GetAddressByClientAsync(int id);
    }
}
