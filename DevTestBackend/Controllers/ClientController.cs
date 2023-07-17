using DevTestBackend.Contract.Service;
using DevTestBackend.Entities.Requests.Clients;
using DevTestBackend.Entities.Results.Clients;
using Microsoft.AspNetCore.Mvc;

namespace DevTestBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _service;

        public ClientController(IClientService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllClient() 
        {
            var result = await _service.GetAllClientAsync().ConfigureAwait(false);

            return result switch
            {
                GetAllClientResult.Success success => Ok(success),
                GetAllClientResult.ValidationError validation => StatusCode(412, validation),
                GetAllClientResult.Failed failed => BadRequest(failed),
                _ => BadRequest(),
            };
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetClient(int id) 
        {
            var result = await _service.GetClientAsync(id).ConfigureAwait(false);

            return result switch
            {
                GetClientResult.Success success => Ok(success),
                GetClientResult.ValidationError validation => StatusCode(412, validation),
                GetClientResult.Failed failed => BadRequest(failed),
                _ => BadRequest(),
            };
        }

        [HttpPost]
        public async Task<IActionResult> InsertClient(InsertClientRequest request) 
        {
            var result = await _service.InsertClientAsync(request).ConfigureAwait(false);

            return result switch
            {
                InsertClientResult.Success success => Ok(success),
                InsertClientResult.ValidationError validation => StatusCode(412, validation),
                InsertClientResult.Failed failed => BadRequest(failed),
                _ => BadRequest(),
            };
        }

        [HttpPut] 
        public async Task<IActionResult> UpdateClient(UpdateClientRequest request) 
        {
            var result = await _service.UpdateClientAsync(request).ConfigureAwait(false);

            return result switch
            {
                UpdateClientResult.Success success => Ok(success),
                UpdateClientResult.ValidationError validation => StatusCode(412, validation),
                UpdateClientResult.Failed failed => BadRequest(failed),
                _ => BadRequest(),
            };
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClient(int id)  
        {
            var result = await _service.DeleteClientAsync(id).ConfigureAwait(false);

            return result switch
            {
                DeleteClientResult.Success success => Ok(success),
                DeleteClientResult.ValidationError validation => StatusCode(412, validation),
                DeleteClientResult.Failed failed => BadRequest(failed),
                _ => BadRequest(),
            };
        }
    }
}
