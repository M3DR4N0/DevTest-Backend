using DevTestBackend.Contract.Service;
using DevTestBackend.Entities.Requests.Clients;
using DevTestBackend.Entities.Results.Clients;

namespace DevTestBackend.Service.Clients
{
    public class ClientErrorService : IClientService
    {
        private readonly IClientService _ClientService;

        public ClientErrorService(IClientService ClientService)
        {
            _ClientService = ClientService;
        }

        public async Task<IDeleteClientResult> DeleteClientAsync(int id)
        {
            try
            {
                return await _ClientService.DeleteClientAsync(id).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                var error = DeleteClientResult.Failed.Instance;

                error.Message = (ex.InnerException ?? ex)!.Message;

                return error;
            }
        }

        public async Task<IGetAllClientResult> GetAllClientAsync()
        {
            try
            {
                return await _ClientService.GetAllClientAsync().ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                var error = GetAllClientResult.Failed.Instance;

                error.Message = (ex.InnerException ?? ex)!.Message;

                return error;
            }
        }

        public async Task<IGetClientResult> GetClientAsync(int id)
        {
            try
            {
                return await _ClientService.GetClientAsync(id).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                var error = GetClientResult.Failed.Instance;

                error.Message = (ex.InnerException ?? ex)!.Message;

                return error;
            }
        }     

        public async Task<IInsertClientResult> InsertClientAsync(InsertClientRequest request)
        {
            try
            {
                return await _ClientService.InsertClientAsync(request).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                var error = InsertClientResult.Failed.Instance;

                error.Message = (ex.InnerException ?? ex)!.Message;

                return error;
            }
        }

        public async Task<IUpdateClientResult> UpdateClientAsync(UpdateClientRequest request)
        {
            try
            {
                return await _ClientService.UpdateClientAsync(request).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                var error = UpdateClientResult.Failed.Instance;

                error.Message = (ex.InnerException ?? ex)!.Message;

                return error;
            }
        }
    }
}
