using AutoMapper;
using IncapSys.DTOs.Usuarios;
using IncapSys.ViewModels;

public class MappingProfileUsuarios : Profile
{
    public MappingProfileUsuarios()
    {
        CreateMap<AgregarUsuario, UsuarioAddDTO>();
    }
}
