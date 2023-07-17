using DevTestBackend.Contract.Repository;
using DevTestBackend.Contract.Service;
using DevTestBackend.Entities.Requests.Clients;
using DevTestBackend.Entities.Results.Clients;

namespace DevTestBackend.Service.Clients
{
    public class ClientValidationService : IClientService
    {
        private readonly IClientService _clientService;
        private readonly IClientRepository _clientRepository;

        public ClientValidationService(IClientService clientService, IClientRepository clientRepository)
        {
            _clientService = clientService;
            _clientRepository = clientRepository;
        }

        public async Task<IDeleteClientResult> DeleteClientAsync(int id) 
        {
            var validation = DeleteClientResult.ValidationError.Instance;
            var validations = new Dictionary<string, string>();

            var exist = await _clientRepository.ExistAsync(id).ConfigureAwait(false);

            if (!exist)
            {
                validations.Add("Not Found", $"Record not found with id ({id})");
                validation.ValidationErrors = validations.ToList();
                return validation;
            }

            return await _clientService.DeleteClientAsync(id).ConfigureAwait(false);
        }     

        public async Task<IGetAllClientResult> GetAllClientAsync()
        {
            return await _clientService.GetAllClientAsync().ConfigureAwait(false);
        }

        public async Task<IGetClientResult> GetClientAsync(int id) 
        {
            var validation = GetClientResult.ValidationError.Instance;
            var validations = new Dictionary<string, string>();

            var exist = await _clientRepository.ExistAsync(id).ConfigureAwait(false);

            if (!exist)
            {
                validations.Add("Not Found", $"Record not found with id ({id})");
                validation.ValidationErrors = validations.ToList();
                return validation;
            }

            return await _clientService.GetClientAsync(id).ConfigureAwait(false);
        }

        public async Task<IInsertClientResult> InsertClientAsync(InsertClientRequest request)
        {
            return await _clientService.InsertClientAsync(request).ConfigureAwait(false);
        }

        public async Task<IUpdateClientResult> UpdateClientAsync(UpdateClientRequest request)
        {
            var validation = UpdateClientResult.ValidationError.Instance;
            var validations = new Dictionary<string, string>();

            var exist = await _clientRepository.ExistAsync(request.ClientId).ConfigureAwait(false);

            if (!exist)
            {
                validations.Add("Not Found", $"Record not found with id ({request.ClientId})");
                validation.ValidationErrors = validations;
                return validation;
            }

            return await _clientService.UpdateClientAsync(request).ConfigureAwait(false);
        }
    }
}
