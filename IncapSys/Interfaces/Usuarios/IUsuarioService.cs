using IncapSys.DTOs.Usuarios;
using IncapSys.Helpers;
using IncapSys.Models.Usuarios;

namespace IncapSys.Interfaces.Usuarios
{
    public interface IUsuarioService : IBaseInterface<Empleados>
    {
        Task<Response<bool>> ExisteUsuario(int idUsuario);
        public Task<Response<Empleados>> CreateAt(UsuarioAddDto model);
        public Task<Response<Empleados>> Actualizar(UsuarioUpdateDto model);

    }
}
