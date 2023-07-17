using DevTestBackend.Contract.Repository;
using DevTestBackend.Contract.Service;
using DevTestBackend.Entities.Models;
using DevTestBackend.Entities.Requests.Perfils;
using DevTestBackend.Entities.Results.Perfils;
using AutoMapper;
using DevTestBackend.Entities.ViewModels.Perfils;


namespace DevTestBackend.Service.Perfils
{
    public class PerfilInnerService : IPerfilService
    {
        private readonly IMapper _mapper;

        private readonly IPerfilRepository _perfilRepository;

        public PerfilInnerService(IMapper mapper, IPerfilRepository perfilRepository)
        {
            _mapper = mapper;

            _perfilRepository = perfilRepository;
        }

        public async Task<IDeletePerfilResult> DeletePerfilAsync(int id) 
        {
            var success = DeletePerfilResult.Success.Instance;

            await _perfilRepository.DeleteAsync(id).ConfigureAwait(false);

            success.Message = "Successfully Deleted";

            return success;
        }

        public async Task<IGetAllPerfilResult> GetAllPerfilAsync()
        {
            var success = GetAllPerfilResult.Success.Instance;

            var result = await _perfilRepository.GetAllAsync().ConfigureAwait(false);
            success.Perfils = _mapper.Map<List<PerfilViewModel>>(result);

            return success;
        }

        public async Task<IGetPerfilResult> GetPerfilAsync(int id)  
        {
            var success = GetPerfilResult.Success.Instance;

            var result = await _perfilRepository.GetAsync(id).ConfigureAwait(false);
            success.Perfil = _mapper.Map<PerfilViewModel>(result);

            return success;
        }

        public async Task<IInsertPerfilResult> InsertPerfilAsync(InsertPerfilRequest request)
        {
            var success = InsertPerfilResult.Success.Instance;

            var perfilToInsert = _mapper.Map<Perfil>(request);

            await _perfilRepository.InsertAsync(perfilToInsert).ConfigureAwait(false);

            success.Message = "Successfully Inserted";

            return success;
        }

        public async Task<IUpdatePerfilResult> UpdatePerfilAsync(UpdatePerfilRequest request)
        {
            var success = UpdatePerfilResult.Success.Instance;

            var perfilToUpdate = _mapper.Map<Perfil>(request);

            await _perfilRepository.UpdateAsync(perfilToUpdate).ConfigureAwait(false);

            success.Message = "Successfully Updated";

            return success;
        }

        public async Task<IGetAllPerfilResult> GetPerfilByClientAsync(int clientId)
        {
            var success = GetAllPerfilResult.Success.Instance;

            var result = await _perfilRepository.GetPerfilByClientAsync(clientId).ConfigureAwait(false);
            success.Perfils = _mapper.Map<List<PerfilViewModel>>(result);

            return success;
        }
    }
}
