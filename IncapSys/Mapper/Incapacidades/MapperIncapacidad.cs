using AutoMapper;
using IncapSys.DTOs.Incapacidades;
using IncapSys.Models.Incapacidades;

namespace IncapSys.Helpers
{
    public class MapperIncapacidad : Profile
    {
        public MapperIncapacidad()
        {
            // Mapeo de Response<DescripcionIncapacidad> a IncapacidadesDto
            CreateMap<Response<DescripcionIncapacidad>, IncapacidadesDto>()
                .ForMember(dest => dest.LugarAccidente, opt => opt.MapFrom(src => src.Result.LugarAccidente))
                .ForMember(dest => dest.Descripcion, opt => opt.MapFrom(src => src.Result.Descripcion))
                .ForMember(dest => dest.FechaSuceso, opt => opt.MapFrom(src => src.Result.FechaSuceso))
                .ForMember(dest => dest.UsuarioId, opt => opt.MapFrom(src => src.Result.UsuarioId));
        }
    }
}
