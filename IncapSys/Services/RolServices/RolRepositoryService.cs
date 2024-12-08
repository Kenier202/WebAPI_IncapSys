using IncapSys.Helpers;
using IncapSys.Models.Rol;
using IncapSys.Repositories.Rol;

namespace IncapSys.Services.RolServices
{
    public class RolRepositoryService : IRolRepository<Roles>
    {
        public Task<Response<Roles>> AddRol(Roles incapacidad)
        {
            throw new NotImplementedException();
        }

        public Task<Response<Roles>> DeleteRol(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Response<IEnumerable<Roles>>> GetAllRoles()
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
