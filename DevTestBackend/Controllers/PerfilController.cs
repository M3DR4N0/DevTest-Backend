using DevTestBackend.Contract.Service;
using DevTestBackend.Entities.Requests.Perfils;
using DevTestBackend.Entities.Results.Perfils;
using Microsoft.AspNetCore.Mvc;

namespace DevTestBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerfilController : ControllerBase
    {
        private readonly IPerfilService _service;

        public PerfilController(IPerfilService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPerfil() 
        {
            var result = await _service.GetAllPerfilAsync().ConfigureAwait(false);

            return result switch
            {
                GetAllPerfilResult.Success success => Ok(success),
                GetAllPerfilResult.ValidationError validation => BadRequest(validation),
                GetAllPerfilResult.Failed failed => BadRequest(failed),
                _ => BadRequest(),
            };
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPerfil(int id) 
        {
            var result = await _service.GetPerfilAsync(id).ConfigureAwait(false);

            return result switch
            {
                GetPerfilResult.Success success => Ok(success),
                GetPerfilResult.ValidationError validation => BadRequest(validation),
                GetPerfilResult.Failed failed => BadRequest(failed),
                _ => BadRequest(),
            };
        }

        [HttpGet("client/{id}")]
        public async Task<IActionResult> GetPerfilByClient(int id)
        {
            var result = await _service.GetPerfilByClientAsync(id).ConfigureAwait(false);

            return result switch
            {
                GetAllPerfilResult.Success success => Ok(success),
                GetAllPerfilResult.ValidationError validation => BadRequest(validation),
                GetAllPerfilResult.Failed failed => BadRequest(failed),
                _ => BadRequest(),
            };
        }

        [HttpPost]
        public async Task<IActionResult> InsertPerfil(InsertPerfilRequest request) 
        {
            var result = await _service.InsertPerfilAsync(request).ConfigureAwait(false);

            return result switch
            {
                InsertPerfilResult.Success success => Ok(success),
                InsertPerfilResult.ValidationError validation => BadRequest(validation),
                InsertPerfilResult.Failed failed => BadRequest(failed),
                _ => BadRequest(),
            };
        }

        [HttpPut] 
        public async Task<IActionResult> UpdatePerfil(UpdatePerfilRequest request) 
        {
            var result = await _service.UpdatePerfilAsync(request).ConfigureAwait(false);

            return result switch
            {
                UpdatePerfilResult.Success success => Ok(success),
                UpdatePerfilResult.ValidationError validation => BadRequest(validation),
                UpdatePerfilResult.Failed failed => BadRequest(failed),
                _ => BadRequest(),
            };
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerfil(int id)  
        {
            var result = await _service.DeletePerfilAsync(id).ConfigureAwait(false);

            return result switch
            {
                DeletePerfilResult.Success success => Ok(success),
                DeletePerfilResult.ValidationError validation => BadRequest(validation),
                DeletePerfilResult.Failed failed => BadRequest(failed),
                _ => BadRequest(),
            };
        }
    }
}
