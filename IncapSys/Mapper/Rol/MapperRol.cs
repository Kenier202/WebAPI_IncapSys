using AutoMapper;
using IncapSys.DTOs.Rol;
using IncapSys.Models.Rol;

namespace IncapSys.Mapper.Rol
{
    public class MapperRol : Profile
    {
        public MapperRol() {

            CreateMap<RolAddDto, Roles>();
        }
    }
}
