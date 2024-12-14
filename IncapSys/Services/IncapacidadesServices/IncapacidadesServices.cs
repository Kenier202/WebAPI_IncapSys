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
                var incapacidad = _mapper.Map<DescripcionIncapacidad>(AddIncapacidad);
        
                var response = await _repositoryService.AddIncapacidad(incapacidad);

                var result = _mapper.Map<IncapacidadesDto>(response);

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

        public async Task<Response<IncapacidadesDto>> Delete(int id)
        {
            if (id < 0) return new Response<IncapacidadesDto>
            {
                IsSucces = false,
                Message = "Ingresa un Id correcto",
                Result = null
            };

            try
            {
                var response = await _repositoryService.DeleteIncapacidad(id);

                var result   = _mapper.Map<IncapacidadesDto>(response);

                if (!response.IsSucces) return new Response<IncapacidadesDto>
                {
                    IsSucces = response.IsSucces,
                    Message  = response.Message,
                    Result   = result,
                };

                return new Response<IncapacidadesDto>
                {
                    IsSucces = response.IsSucces,
                    Message  = response.Message,
                    Result   = result,
                };
            }
            catch (Exception ex) 
            {
                return new Response<IncapacidadesDto>
                {
                    IsSucces = false,
                    Message  = ex.Message,
                    Result   = null
                };
            }
        }

        public Task<Response<bool>> ExisteIncapacidad(int idUsuario)
        {
            throw new NotImplementedException();
        }

        public async Task<Response<IEnumerable<IncapacidadesDto>>> getAll()
        {
            try
            {
                var incapacidades = await _repositoryService.GetAllIncapacidades();

                if (incapacidades == null || !incapacidades.IsSucces) return new Response<IEnumerable<IncapacidadesDto>>
                {
                    IsSucces = false,
                    Message  = "Rellene los campos",
                    Result   = null
                };

                var result = _mapper.Map<IEnumerable<IncapacidadesDto>>(incapacidades.Result);

                return new Response<IEnumerable<IncapacidadesDto>>
                {
                    IsSucces = incapacidades.IsSucces,
                    Message = incapacidades.Message,
                    Result = result
                };


            }
            catch (Exception ex) {
                return new Response<IEnumerable<IncapacidadesDto>>
                {
                    IsSucces = false,
                    Message = ex.Message,
                    Result = null
                };
            }
        }

        public Task<Response<IncapacidadesDto>> GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}



