using AutoMapper;
using IncapSys.DTOs.Usuarios;
using IncapSys.Models.Usuarios;
using IncapSys.ViewModels;

namespace IncapSys.MappingProfiles 
{
    public class MappingProfileUsuarios : Profile
    {
        public MappingProfileUsuarios()
        {
            CreateMap<AgregarUsuario, UsuarioAddDto>();
            CreateMap<ActualizarUsuario, UsuarioAddDto>();
            CreateMap<UsuarioAddDto, Empleados>();
            CreateMap<ActualizarUsuario, UsuarioUpdateDto>();
            CreateMap<UsuarioUpdateDto, Empleados>();

        }
    }
}
