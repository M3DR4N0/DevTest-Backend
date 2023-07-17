using AutoMapper;
using DevTestBackend.Entities.Models;
using DevTestBackend.Entities.Requests.Addresses;
using DevTestBackend.Entities.Requests.Clients;
using DevTestBackend.Entities.Requests.Perfils;
using DevTestBackend.Entities.ViewModels.Addresses;
using DevTestBackend.Entities.ViewModels.Clients;
using DevTestBackend.Entities.ViewModels.Perfils;

namespace DevTestBackend.Helper
{
    public class MapperProfile : Profile
    {
        public MapperProfile() 
        {
            #region Client
            CreateMap<Client, ClientViewModel>();
            CreateMap<InsertClientRequest, Client>();
            CreateMap<UpdateClientRequest, Client>();
            #endregion

            #region Perfil
            CreateMap<Perfil, PerfilViewModel>()
                .ForMember(x => x.ClientName, x => x.MapFrom(m => m.Client.Name));
            CreateMap<InsertPerfilRequest, Perfil>();
            CreateMap<UpdatePerfilRequest, Perfil>();
            #endregion

            #region Address
            CreateMap<Address, AddressViewModel>()
                .ForMember(x => x.ClientName, x => x.MapFrom(m => m.Client.Name));
            CreateMap<InsertAddressRequest, Address>();
            CreateMap<UpdateAddressRequest, Address>();
            #endregion
        }
    }
}
