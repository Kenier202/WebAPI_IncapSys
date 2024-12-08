using IncapSys.Helpers;

namespace IncapSys.Repositories.Usuarios

{
    public interface IUsuariosRepository<T>
    {
        public Task<Response<IEnumerable<T>>> GetAllUsuarios();
        public Task<Response<T>> GetUsuarioById(int id);
        public Task<Response<T>> AddUsuario(T incapacidad);
        public Task<Response<T>> DeleteUsuario(int id);
        public Task<Response<T>> UpdateUsuario(T incapacidad);
    }
}
