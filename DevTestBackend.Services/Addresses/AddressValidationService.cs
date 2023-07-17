using DevTestBackend.Contract.Repository;
using DevTestBackend.Contract.Service;
using DevTestBackend.Entities.Requests.Addresses;
using DevTestBackend.Entities.Results.Addresses;

namespace DevTestBackend.Service.Addresss
{
    public class AddressValidationService : IAddressService
    {
        private readonly IAddressService _AddressService;
        private readonly IAddressRepository _AddressRepository;

        public AddressValidationService(IAddressService AddressService, IAddressRepository AddressRepository)
        {
            _AddressService = AddressService;
            _AddressRepository = AddressRepository;
        }

        public async Task<IDeleteAddressResult> DeleteAddressAsync(int id) 
        {
            return await _AddressService.DeleteAddressAsync(id).ConfigureAwait(false);
        }

        public async Task<IGetAllAddressResult> GetAllAddressAsync()
        {
            return await _AddressService.GetAllAddressAsync().ConfigureAwait(false);
        }

        public async Task<IGetAddressResult> GetAddressAsync(int id) 
        {
            return await _AddressService.GetAddressAsync(id).ConfigureAwait(false);
        }

        public async Task<IInsertAddressResult> InsertAddressAsync(InsertAddressRequest request)
        {
            return await _AddressService.InsertAddressAsync(request).ConfigureAwait(false);
        }

        public async Task<IUpdateAddressResult> UpdateAddressAsync(UpdateAddressRequest request)
        {
            return await _AddressService.UpdateAddressAsync(request).ConfigureAwait(false);
        }

        public async Task<IGetAllAddressResult> GetAddressByClientAsync(int clientId)
        {
            return await _AddressService.GetAddressByClientAsync(clientId).ConfigureAwait(false);
        }
    }
}
