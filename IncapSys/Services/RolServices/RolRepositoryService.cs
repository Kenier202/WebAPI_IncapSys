using AutoMapper;
using IncapSys.Helpers;
using IncapSys.Models;
using IncapSys.Models.Rol;
using IncapSys.Repositories.Rol;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IncapSys.Services.RolServices
{
    public class RolRepositoryService : IRolRepository<Roles>
    {
        private readonly ApplicationDbContext _DbContext;
        private readonly IMapper _Mapper;
        public RolRepositoryService(ApplicationDbContext dbContext, IMapper Mapper) {
            this._DbContext = dbContext;
            this._Mapper = Mapper;
        }

        async public Task<Response<IEnumerable<Roles>>> GetAllRoles()
        {
            try
            {
                var roles = await _DbContext.Roles.ToListAsync();

                if (!roles.Any()) return new Response<IEnumerable<Roles>> {
                    IsSucces = false,
                    Message = "No se han encontrado roles",
                    Result = null
                };

                return new Response<IEnumerable<Roles>>
                {
                    IsSucces = true,
                    Message = "Roles encontrados",
                    Result = roles
                };
            }
            catch (DbUpdateException dbEx)
            { 
                return new Response<IEnumerable<Roles>>
                {
                    IsSucces = false,
                    Message = $"Database error: {dbEx.Message}",
                    Result = null
                };
            }
            catch (Exception ex) {
                return new Response<IEnumerable<Roles>> {
                    IsSucces = true,
                    Message= ex.Message,
                    Result = null
                };
            }

        }

        public async Task<Response<Roles>> GetRolById(int id)
        {
            try
            {
                var rol = await _DbContext.Roles.FirstOrDefaultAsync(x => x.Id == id);

                if (rol == null) return new Response<Roles>
                {
                    IsSucces = false,
                    Message = "Rol no encontrado",
                    Result = null
                };

                return new Response<Roles>
                {
                    IsSucces = true,
                    Message = "Rol encontrado",
                    Result = rol
                };

            }
            catch (DbUpdateException dbEx) {
                return new Response<Roles>
                {
                    IsSucces = false,
                    Message = dbEx.Message,
                    Result = null
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
 
        public async Task<Response<Roles>> AddRol(Roles rol)
        {
            if (rol == null)
            {
                return new Response<Roles>
                {
                    IsSucces = false,
                    Message = "El rol no puede ser nulo",
                    Result = null
                };
            }

            try
            {
                if (string.IsNullOrEmpty(rol.Name))
                {
                    return new Response<Roles>
                    {
                        IsSucces = false,
                        Message = "El nombre del rol es obligatorio",
                        Result = null
                    };
                }

                await _DbContext.Roles.AddAsync(rol);
                var result = await _DbContext.SaveChangesAsync();

                if (result < 1)
                {
                    return new Response<Roles>
                    {
                        IsSucces = false,
                        Message = "No se pudo agregar el rol a la base de datos",
                        Result = null
                    };
                }

                return new Response<Roles>
                {
                    IsSucces = true,
                    Message = "Rol agregado exitosamente",
                    Result = rol
                };
            }
            catch (DbUpdateException dbEx)
            {
                return new Response<Roles>
                {
                    IsSucces = false,
                    Message = $"Error al actualizar la base de datos: {dbEx.Message}",
                    Result = null
                };
            }
            catch (Exception ex)
            {
                // Manejo de errores generales
                return new Response<Roles>
                {
                    IsSucces = false,
                    Message = $"Ocurrió un error inesperado: {ex.Message}",
                    Result = null
                };
            }
        }


        public async Task<Response<Roles>> DeleteRol(int id)
        {
            var response = await _DbContext.Roles.FindAsync(id);

            try
            {
                if (response == null) return new Response<Roles>
                {
                    IsSucces = false,
                    Message  = "Rol no encontrado",
                    Result   = null
                };

                _DbContext.Remove(response);
                await _DbContext.SaveChangesAsync();


                return new Response<Roles>
                {
                    IsSucces = true,
                    Message = "Rol eliminado exitosamente",
                    Result = response
                };
            }
            catch (DbUpdateException dbEx)
            {
                return new Response<Roles>
                {
                    IsSucces = false,
                    Message = $"Error al actualizar la base de datos: {dbEx.Message}",
                    Result = null
                };
            }
            catch (Exception ex)
            {
                // Manejo de errores generales
                return new Response<Roles>
                {
                    IsSucces = false,
                    Message = $"Ocurrió un error inesperado: {ex.Message}",
                    Result = null
                };
            }



        }

        public Task<Response<Roles>> UpdateRol(Roles incapacidad)
        {
            throw new NotImplementedException();
        }

     
    }
}
