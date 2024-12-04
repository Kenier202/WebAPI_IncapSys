using AutoMapper;
using IncapSys.DTOs.Usuarios;
using IncapSys.ViewModels;

namespace IncapSys.MappingProfiles 
{
    public class MappingProfileUsuarios : Profile
    {
        public MappingProfileUsuarios()
        {
            CreateMap<AgregarUsuario, UsuarioAddDto>();
        }
    }
}
