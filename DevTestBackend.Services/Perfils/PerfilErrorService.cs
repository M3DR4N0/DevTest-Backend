using DevTestBackend.Contract.Service;
using DevTestBackend.Entities.Requests.Perfils;
using DevTestBackend.Entities.Results.Perfils;

namespace DevTestBackend.Service.Perfils
{
    public class PerfilErrorService : IPerfilService
    {
        private readonly IPerfilService _perfilService;

        public PerfilErrorService(IPerfilService perfilService)
        {
            _perfilService = perfilService;
        }

        public async Task<IDeletePerfilResult> DeletePerfilAsync(int id)
        {
            try
            {
                return await _perfilService.DeletePerfilAsync(id).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                var error = DeletePerfilResult.Failed.Instance;

                error.Message = (ex.InnerException ?? ex)!.Message;

                return error;
            }
        }

        public async Task<IGetAllPerfilResult> GetAllPerfilAsync()
        {
            try
            {
                return await _perfilService.GetAllPerfilAsync().ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                var error = GetAllPerfilResult.Failed.Instance;                

                error.Message = (ex.InnerException ?? ex)!.Message;

                return error;
            }
        }

        public async Task<IGetPerfilResult> GetPerfilAsync(int id)
        {
            try
            {
                return await _perfilService.GetPerfilAsync(id).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                var error = GetPerfilResult.Failed.Instance;

                error.Message = (ex.InnerException ?? ex)!.Message;

                return error;
            }
        }

        public async Task<IInsertPerfilResult> InsertPerfilAsync(InsertPerfilRequest request)
        {
            try
            {
                return await _perfilService.InsertPerfilAsync(request).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                var error = InsertPerfilResult.Failed.Instance;

                error.Message = (ex.InnerException ?? ex)!.Message;

                return error;
            }
        }

        public async Task<IUpdatePerfilResult> UpdatePerfilAsync(UpdatePerfilRequest request)
        {
            try
            {
                return await _perfilService.UpdatePerfilAsync(request).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                var error = UpdatePerfilResult.Failed.Instance;

                error.Message = (ex.InnerException ?? ex)!.Message;

                return error;
            }
        }

        public async Task<IGetAllPerfilResult> GetPerfilByClientAsync(int clientId)
        {
            try
            {
                return await _perfilService.GetPerfilByClientAsync(clientId).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                var error = GetAllPerfilResult.Failed.Instance;

                error.Message = (ex.InnerException ?? ex)!.Message;

                return error;
            }
        }
    }
}
