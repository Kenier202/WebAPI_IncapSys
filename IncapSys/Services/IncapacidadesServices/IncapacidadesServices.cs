using AutoMapper;
using IncapSys.DTOs.Incapacidades;
using IncapSys.DTOs.Usuarios;
using IncapSys.Helpers;
using IncapSys.Interfaces;
using IncapSys.Interfaces.Incapacidades;
using IncapSys.Models.Incapacidades;
using IncapSys.Models.Usuarios;
using IncapSys.Repositories.Incapacidades;

namespace IncapSys.Services.IncapacidadesServices
{
    public class IncapacidadesServices : IIncapacidadesService
    {
        private readonly IMapper _mapper;
        IIncapacidadesRepository<DescripcionIncapacidad> _repositoryService;
        public IncapacidadesServices(IMapper Mapper, IIncapacidadesRepository<DescripcionIncapacidad> incapacidadesRepository) {
            this._mapper = Mapper;
            this._repositoryService = incapacidadesRepository;
        }

        public Task<Response<IncapacidadesDto>> Actualizar(IncapacidadesUpdateDto model)
        {
            throw new NotImplementedException();
        }

        public async Task<Response<IncapacidadesDto>> CreateAt(IncapacidadesAddDto AddIncapacidad)
        {
            try
            {
                //var incapacidad = _mapper.Map<DescripcionIncapacidad>(AddIncapacidad);
                var incapacidad = new DescripcionIncapacidad() {
                    Descripcion = AddIncapacidad.Descripcion,
                    LugarAccidente = AddIncapacidad.LugarAccidente,
                    FechaSuceso = DateTime.Now,
                    UsuarioId = AddIncapacidad.UsuarioId
                };
                var response = await _repositoryService.AddIncapacidad(incapacidad);

                var result = _mapper.Map<IncapacidadesDto>(response);
                //var result = new IncapacidadesDto()
                //{
                //    UsuarioId = response.Result.Id,
                //    Descripcion = response.Result.Descripcion,
                //    FechaSuceso = response.Result.FechaSuceso,
                //    LugarAccidente = response.Result.LugarAccidente,
                //};

                if (!response.IsSucces) return new Response<IncapacidadesDto>
                {
                    IsSucces = false,
                    Message = response.Message,
                    Result = result,
                };

                return new Response<IncapacidadesDto>
                {
                    IsSucces = true,
                    Message = response.Message,
                    Result = result,
                };
            }
            catch (Exception ex) {
                return new Response<IncapacidadesDto>
                {
                    IsSucces = false,
                    Message = ex.Message,
                    Result = null
                };
            }
        }

        public Task<Response<IncapacidadesDto>> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Response<bool>> ExisteIncapacidad(int idUsuario)
        {
            throw new NotImplementedException();
        }

        public Task<Response<IEnumerable<IncapacidadesDto>>> getAll()
        {
            throw new NotImplementedException();
        }

        public Task<Response<IncapacidadesDto>> GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}



