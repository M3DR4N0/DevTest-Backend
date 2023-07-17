using AutoMapper;
using DevTestBackend.Contract.Repository;
using DevTestBackend.Contract.Service;
using DevTestBackend.Entities.Models;
using DevTestBackend.Entities.Requests.Clients;
using DevTestBackend.Entities.Results.Clients;
using DevTestBackend.Entities.ViewModels.Clients;

namespace DevTestBackend.Service.Clients
{
    public class ClientInnerService : IClientService
    {
        private readonly IMapper _mapper;
        private readonly IClientRepository _clientRepository;

        public ClientInnerService(IMapper mapper, IClientRepository clientRepository)
        {
            _mapper = mapper;
            _clientRepository = clientRepository;
        }

        public async Task<IDeleteClientResult> DeleteClientAsync(int id) 
        {
            var success = DeleteClientResult.Success.Instance;

            await _clientRepository.BulkDeleteAsync(id).ConfigureAwait(false);
            await _clientRepository.DeleteAsync(id).ConfigureAwait(false);

            success.Message = "Successfully Deleted";

            return success;
        }

        public async Task<IGetAllClientResult> GetAllClientAsync()
        {
            var success = GetAllClientResult.Success.Instance;

            var result = await _clientRepository.GetAllAsync().ConfigureAwait(false);
            success.Clients = _mapper.Map<List<ClientViewModel>>(result);

            return success;
        }

        public async Task<IGetClientResult> GetClientAsync(int id) 
        {
            var success = GetClientResult.Success.Instance;

            var result = await _clientRepository.GetAsync(id).ConfigureAwait(false);
            success.Client = _mapper.Map<ClientViewModel>(result);

            return success;
        }

        public async Task<IInsertClientResult> InsertClientAsync(InsertClientRequest request)
        {
            var success = InsertClientResult.Success.Instance;

            var ClientToInsert = _mapper.Map<Client>(request);

            await _clientRepository.InsertAsync(ClientToInsert).ConfigureAwait(false);

            success.Message = "Successfully Inserted";

            return success;
        }

        public async Task<IUpdateClientResult> UpdateClientAsync(UpdateClientRequest request)
        {
            var success = UpdateClientResult.Success.Instance;

            var ClientToUpdate = _mapper.Map<Client>(request);

            await _clientRepository.UpdateAsync(ClientToUpdate).ConfigureAwait(false);

            success.Message = "Successfully Updated";

            return success;
        }
    }
}
