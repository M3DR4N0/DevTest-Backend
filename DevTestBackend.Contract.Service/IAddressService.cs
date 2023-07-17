using DevTestBackend.Entities.Requests.Addresses;
using DevTestBackend.Entities.Results.Addresses;

namespace DevTestBackend.Contract.Service
{
    public interface IAddressService 
    {
        Task<IGetAllAddressResult> GetAllAddressAsync(); 
        Task<IGetAddressResult> GetAddressAsync(int id);
        Task<IGetAllAddressResult> GetAddressByClientAsync(int clientId);
        Task<IInsertAddressResult> InsertAddressAsync(InsertAddressRequest request);
        Task<IUpdateAddressResult> UpdateAddressAsync(UpdateAddressRequest request);  
        Task<IDeleteAddressResult> DeleteAddressAsync(int id);
    }
}
