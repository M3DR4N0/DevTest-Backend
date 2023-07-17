using DevTestBackend.Entities.Requests.Clients;
using DevTestBackend.Entities.Results.Clients;

namespace DevTestBackend.Contract.Service
{
    public interface IClientService 
    {
        Task<IGetAllClientResult> GetAllClientAsync(); 
        Task<IGetClientResult> GetClientAsync(int id); 
        Task<IInsertClientResult> InsertClientAsync(InsertClientRequest request);
        Task<IUpdateClientResult> UpdateClientAsync(UpdateClientRequest request);  
        Task<IDeleteClientResult> DeleteClientAsync(int id);
    }
}
