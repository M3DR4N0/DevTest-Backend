using Azure.Core;
using DevTestBackend.Contract.Service;
using DevTestBackend.Entities.Requests.Addresses;
using DevTestBackend.Entities.Results.Addresses;

namespace DevTestBackend.Service.Addresses 
{
    public class AddressErrorService : IAddressService
    {
        private readonly IAddressService _addressService;

        public AddressErrorService(IAddressService addressService)
        {
            _addressService = addressService;
        }

        public async Task<IDeleteAddressResult> DeleteAddressAsync(int id)
        {
            try
            {
                return await _addressService.DeleteAddressAsync(id).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                var error = DeleteAddressResult.Failed.Instance;

                error.Message = (ex.InnerException ?? ex)!.Message;

                return error;
            }
        }

        public async Task<IGetAllAddressResult> GetAllAddressAsync()
        {
            try
            {
                return await _addressService.GetAllAddressAsync().ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                var error = GetAllAddressResult.Failed.Instance;                

                error.Message = (ex.InnerException ?? ex)!.Message;

                return error;
            }
        }

        public async Task<IGetAddressResult> GetAddressAsync(int id)
        {
            try
            {
                return await _addressService.GetAddressAsync(id).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                var error = GetAddressResult.Failed.Instance;

                error.Message = (ex.InnerException ?? ex)!.Message;

                return error;
            }
        }

        public async Task<IInsertAddressResult> InsertAddressAsync(InsertAddressRequest request)
        {
            try
            {
                return await _addressService.InsertAddressAsync(request).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                var error = InsertAddressResult.Failed.Instance;

                error.Message = (ex.InnerException ?? ex)!.Message;

                return error;
            }
        }

        public async Task<IUpdateAddressResult> UpdateAddressAsync(UpdateAddressRequest request)
        {
            try
            {
                return await _addressService.UpdateAddressAsync(request).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                var error = UpdateAddressResult.Failed.Instance;

                error.Message = (ex.InnerException ?? ex)!.Message;

                return error;
            }
        }

        public async Task<IGetAllAddressResult> GetAddressByClientAsync(int clientId)
        {
            try
            {
                return await _addressService.GetAddressByClientAsync(clientId).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                var error = GetAllAddressResult.Failed.Instance;

                error.Message = (ex.InnerException ?? ex)!.Message;

                return error;
            }
        }
    }
}
