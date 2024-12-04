using IncapSys.DTOs.Usuarios;
using IncapSys.Helpers;
using IncapSys.Models.Usuarios;

namespace IncapSys.Interfaces.Usuarios
{
    public interface IUsuarioService : IBaseInterface<Empleados, UsuarioAddDto
        >
    {
        Task<Response<bool>> ExisteUsuario(int idUsuario);

    }
}
