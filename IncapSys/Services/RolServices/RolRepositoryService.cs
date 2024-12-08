using AutoMapper;
using IncapSys.Helpers;
using IncapSys.Models;
using IncapSys.Models.Rol;
using IncapSys.Repositories.Rol;
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


        public Task<Response<Roles>> AddRol(Roles incapacidad)
        {
            throw new NotImplementedException();
        }

        public Task<Response<Roles>> DeleteRol(int id)
        {
            throw new NotImplementedException();
        }


        public Task<Response<Roles>> GetRolById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Response<Roles>> UpdateRol(Roles incapacidad)
        {
            throw new NotImplementedException();
        }
    }
}
