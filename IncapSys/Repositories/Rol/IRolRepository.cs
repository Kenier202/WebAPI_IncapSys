using IncapSys.Helpers;

namespace IncapSys.Repositories.Rol
{
    public interface IRolRepository<T>
    {
        public Task<Response<IEnumerable<T>>> GetAllRoles();
        public Task<Response<T>> GetRolById(int id);
        public Task<Response<T>> AddRol(T incapacidad);
        public Task<Response<T>> DeleteRol(int id);
        public Task<Response<T>> UpdateRol(T incapacidad);
    }
}
