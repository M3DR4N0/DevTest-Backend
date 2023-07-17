using DevTestBackend.Entities.Requests.Perfils;
using DevTestBackend.Entities.Results.Perfils;

namespace DevTestBackend.Contract.Service
{
    public interface IPerfilService 
    {
        Task<IGetAllPerfilResult> GetAllPerfilAsync(); 
        Task<IGetPerfilResult> GetPerfilAsync(int id);
        Task<IGetAllPerfilResult> GetPerfilByClientAsync(int clientId);

        Task<IInsertPerfilResult> InsertPerfilAsync(InsertPerfilRequest request);
        Task<IUpdatePerfilResult> UpdatePerfilAsync(UpdatePerfilRequest request);  
        Task<IDeletePerfilResult> DeletePerfilAsync(int id);
    }
}
