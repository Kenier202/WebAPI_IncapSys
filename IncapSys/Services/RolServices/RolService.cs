using AutoMapper;
using IncapSys.DTOs.Rol;
using IncapSys.Helpers;
using IncapSys.Interfaces.Rol;
using IncapSys.Models.Rol;
using IncapSys.Models.Usuarios;
using IncapSys.Repositories.Rol;
using Microsoft.AspNetCore.DataProtection.Repositories;

namespace IncapSys.Services.RolServices
{
    public class RolService : IRolService
    {
        private readonly IRolRepository<Roles> _RolRepositoryService;
        private readonly IMapper _MappingRol;
        public RolService(IRolRepository<Roles> rolRepositoryService, IMapper Mapper) {
            this._RolRepositoryService = rolRepositoryService;
            this._MappingRol = Mapper;
        }

        public Task<Response<Roles>> Actualizar(RolUpdateDto model)
        {
            throw new NotImplementedException();
        }

        public async Task<Response<Roles>> CreateAt(RolAddDto rolAdd)
        {
            try
            {
                var rol = _MappingRol.Map<Roles>(rolAdd);
                var response = await _RolRepositoryService.AddRol(rol);

                if (!response.IsSucces)
                {
                    return new Response<Roles>
                    {
                        IsSucces = false,
                        Message  = response.Message,
                        Result   = response.Result
                    };
                }

                return new Response<Roles> 
                {
                    IsSucces = response.IsSucces,
                    Message = response.Message,
                    Result = response.Result
                };
            }
            catch (Exception ex) {
                return new Response<Roles>
                {
                    IsSucces = false,
                    Message  = ex.Message,
                    Result   = null
                };
            }
        }

        public async Task<Response<Roles>> Delete(int id)
        {
            try
            {
                var response = await _RolRepositoryService.DeleteRol(id);

                if (response == null) return new Response<Roles>
                {
                    IsSucces = response.IsSucces,
                    Message = response.Message,
                    Result = response.Result
                };

                return new Response<Roles>
                {
                    IsSucces = response.IsSucces,
                    Message = response.Message,
                    Result = response.Result
                };
            }
            catch (Exception ex)
            {
                return new Response<Roles>
                {
                    IsSucces = false,
                    Message = ex.Message,
                    Result = null
                };

            }
        }

        public Task<Response<bool>> ExisteRol(int idUsuario)
        {
            throw new NotImplementedException();
        }

        async public Task<Response<IEnumerable<Roles>>> getAll()
        {
            try
            {
                var response = await _RolRepositoryService.GetAllRoles();

                if (response == null) return new Response<IEnumerable<Roles>> {
                    IsSucces = response.IsSucces,
                    Message = response.Message,
                    Result = response.Result
                };

                return new Response<IEnumerable<Roles>> { 
                    IsSucces = response.IsSucces,
                    Message = response.Message,
                    Result = response.Result
                };
            }
            catch (Exception ex) {
                return new Response<IEnumerable<Roles>> {
                    IsSucces = false,
                    Message = ex.Message,
                    Result = null
                };
            }
        }

        public async Task<Response<Roles>> GetById(int id)
        {
            try
            {
                var response = await _RolRepositoryService.GetRolById(id);

                if (response == null) return new Response<Roles>
                {
                    IsSucces = response.IsSucces,
                    Message = response.Message,
                    Result = response.Result
                };

                return new Response<Roles>
                {
                    IsSucces = response.IsSucces,
                    Message = response.Message,
                    Result = response.Result
                };
            }
            catch (Exception ex) {
                return new Response<Roles>
                {
                    IsSucces = false,
                    Message = ex.Message,
                    Result = null
                };
            
            }
        }


    
    }
}
