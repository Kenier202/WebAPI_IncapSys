﻿using AutoMapper;
using IncapSys.DTOs.Incapacidades;
using IncapSys.Helpers;
using IncapSys.Models.Incapacidades;
using static IncapSys.ViewModels.Incapacidades.AgregarIncapacidad;
using static IncapSys.ViewModels.Incapacidades.UpdateIncapacidad;

namespace IncapSys.Mapper.Incapacidades
{
    public class MapperIncapacidad : Profile
    {
        public MapperIncapacidad() {
            CreateMap<Response<DescripcionIncapacidad>, IncapacidadesDto>()
               .ForMember(dest => dest.LugarAccidente, opt => opt.MapFrom(src => src.Result.LugarAccidente))
               .ForMember(dest => dest.Descripcion, opt => opt.MapFrom(src => src.Result.Descripcion))
               .ForMember(dest => dest.FechaSuceso, opt => opt.MapFrom(src => src.Result.FechaSuceso))
               .ForMember(dest => dest.UsuarioId, opt => opt.MapFrom(src => src.Result.UsuarioId))
               .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Result.Id));

            CreateMap<DescripcionIncapacidad, IncapacidadesDto>()
                .ForMember(dest => dest.NombreUsuario, opt => opt.MapFrom(src => src.Usuario));

            CreateMap<IncapacidadesAddDto, DescripcionIncapacidad>()
                .ForMember(dest => dest.FechaSuceso, opt => opt.MapFrom(src => DateTime.Now));

            CreateMap<IncapacidadesUpdateDto, DescripcionIncapacidad>()
              .ForMember(dest => dest.FechaSuceso, opt => opt.MapFrom(src => DateTime.Now));

            CreateMap<AgregarIncapacidadViewModel, IncapacidadesAddDto>();
            CreateMap<UpdateIncapacidadViewModel, IncapacidadesUpdateDto>();


        }
    }
}
