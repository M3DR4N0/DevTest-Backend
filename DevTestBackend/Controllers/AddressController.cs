using DevTestBackend.Contract.Service;
using DevTestBackend.Entities.Requests.Addresses;
using DevTestBackend.Entities.Results.Addresses;
using Microsoft.AspNetCore.Mvc;

namespace DevTestBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAddressService _service;

        public AddressController(IAddressService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAddress() 
        {
            var result = await _service.GetAllAddressAsync().ConfigureAwait(false);

            return result switch
            {
                GetAllAddressResult.Success success => Ok(success),
                GetAllAddressResult.ValidationError validation => BadRequest(validation),
                GetAllAddressResult.Failed failed => BadRequest(failed),
                _ => BadRequest(),
            };
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAddress(int id) 
        {
            var result = await _service.GetAddressAsync(id).ConfigureAwait(false);

            return result switch
            {
                GetAddressResult.Success success => Ok(success),
                GetAddressResult.ValidationError validation => BadRequest(validation),
                GetAddressResult.Failed failed => BadRequest(failed),
                _ => BadRequest(),
            };
        }

        [HttpGet("client/{id}")]
        public async Task<IActionResult> GetAddressByClient(int id) 
        {
            var result = await _service.GetAddressByClientAsync(id).ConfigureAwait(false);

            return result switch
            {
                GetAllAddressResult.Success success => Ok(success),
                GetAllAddressResult.ValidationError validation => BadRequest(validation),
                GetAllAddressResult.Failed failed => BadRequest(failed),
                _ => BadRequest(),
            };
        }

        [HttpPost]
        public async Task<IActionResult> InsertAddress(InsertAddressRequest request) 
        {
            var result = await _service.InsertAddressAsync(request).ConfigureAwait(false);

            return result switch
            {
                InsertAddressResult.Success success => Ok(success),
                InsertAddressResult.ValidationError validation => BadRequest(validation),
                InsertAddressResult.Failed failed => BadRequest(failed),
                _ => BadRequest(),
            };
        }

        [HttpPut] 
        public async Task<IActionResult> UpdateAddress(UpdateAddressRequest request) 
        {
            var result = await _service.UpdateAddressAsync(request).ConfigureAwait(false);

            return result switch
            {
                UpdateAddressResult.Success success => Ok(success),
                UpdateAddressResult.ValidationError validation => BadRequest(validation),
                UpdateAddressResult.Failed failed => BadRequest(failed),
                _ => BadRequest(),
            };
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAddress(int id)  
        {
            var result = await _service.DeleteAddressAsync(id).ConfigureAwait(false);

            return result switch
            {
                DeleteAddressResult.Success success => Ok(success),
                DeleteAddressResult.ValidationError validation => BadRequest(validation),
                DeleteAddressResult.Failed failed => BadRequest(failed),
                _ => BadRequest(),
            };
        }
    }
}
