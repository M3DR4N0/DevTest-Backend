using DevTestBackend.Contract.Repository;
using DevTestBackend.Contract.Service;
using DevTestBackend.Entities.Requests.Perfils;
using DevTestBackend.Entities.Results.Perfils;

namespace DevTestBackend.Service.Perfils
{
    public class PerfilValidationService : IPerfilService
    {
        private readonly IPerfilService _perfilService;
        private readonly IPerfilRepository _perfilRepository;

        public PerfilValidationService(IPerfilService perfilService, IPerfilRepository perfilRepository)
        {
            _perfilService = perfilService;
            _perfilRepository = perfilRepository;
        }

        public async Task<IDeletePerfilResult> DeletePerfilAsync(int id) 
        {
            return await _perfilService.DeletePerfilAsync(id).ConfigureAwait(false);
        }

        public async Task<IGetAllPerfilResult> GetAllPerfilAsync()
        {
            return await _perfilService.GetAllPerfilAsync().ConfigureAwait(false);
        }

        public async Task<IGetPerfilResult> GetPerfilAsync(int id) 
        {
            return await _perfilService.GetPerfilAsync(id).ConfigureAwait(false);
        }

        public async Task<IInsertPerfilResult> InsertPerfilAsync(InsertPerfilRequest request)
        {
            return await _perfilService.InsertPerfilAsync(request).ConfigureAwait(false);
        }

        public async Task<IUpdatePerfilResult> UpdatePerfilAsync(UpdatePerfilRequest request)
        {
            return await _perfilService.UpdatePerfilAsync(request).ConfigureAwait(false);
        }

        public async Task<IGetAllPerfilResult> GetPerfilByClientAsync(int clientId)
        {
            return await _perfilService.GetPerfilByClientAsync(clientId).ConfigureAwait(false);
        }
    }
}
