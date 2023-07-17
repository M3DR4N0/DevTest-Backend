using DevTestBackend.Contract.Repository;
using DevTestBackend.Contract.Service;
using DevTestBackend.Entities.Models;
using DevTestBackend.Entities.Requests.Addresses;
using DevTestBackend.Entities.Results.Addresses;
using AutoMapper;
using DevTestBackend.Entities.ViewModels.Addresses;
using Azure.Core;


namespace DevTestBackend.Service.Addresss
{
    public class AddressInnerService : IAddressService
    {
        private readonly IMapper _mapper;

        private readonly IAddressRepository _AddressRepository;

        public AddressInnerService(IMapper mapper, IAddressRepository AddressRepository)
        {
            _mapper = mapper;

            _AddressRepository = AddressRepository;
        }

        public async Task<IDeleteAddressResult> DeleteAddressAsync(int id) 
        {
            var success = DeleteAddressResult.Success.Instance;

            await _AddressRepository.DeleteAsync(id).ConfigureAwait(false);

            success.Message = "Successfully Deleted";

            return success;
        }

        public async Task<IGetAllAddressResult> GetAllAddressAsync()
        {
            var success = GetAllAddressResult.Success.Instance;

            var result = await _AddressRepository.GetAllAsync().ConfigureAwait(false);
            success.Addresses = _mapper.Map<List<AddressViewModel>>(result);

            return success;
        }

        public async Task<IGetAddressResult> GetAddressAsync(int id)  
        {
            var success = GetAddressResult.Success.Instance;

            var result = await _AddressRepository.GetAsync(id).ConfigureAwait(false);
            success.Address = _mapper.Map<AddressViewModel>(result);

            return success;
        }

        public async Task<IInsertAddressResult> InsertAddressAsync(InsertAddressRequest request)
        {
            var success = InsertAddressResult.Success.Instance;

            var AddressToInsert = _mapper.Map<Address>(request);

            await _AddressRepository.InsertAsync(AddressToInsert).ConfigureAwait(false);

            success.Message = "Successfully Inserted";

            return success;
        }

        public async Task<IUpdateAddressResult> UpdateAddressAsync(UpdateAddressRequest request)
        {
            var success = UpdateAddressResult.Success.Instance;

            var AddressToUpdate = _mapper.Map<Address>(request);

            await _AddressRepository.UpdateAsync(AddressToUpdate).ConfigureAwait(false);

            success.Message = "Successfully Updated";

            return success;
        }

        public async Task<IGetAllAddressResult> GetAddressByClientAsync(int clientId)
        {
            var success = GetAllAddressResult.Success.Instance;

            var result = await _AddressRepository.GetAddressByClientAsync(clientId).ConfigureAwait(false);
            success.Addresses = _mapper.Map<List<AddressViewModel>>(result);

            return success;
        }
    }
}
