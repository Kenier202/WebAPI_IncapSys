using IncapSys.DTOs.Usuarios;
using IncapSys.Helpers;
using IncapSys.Models.Usuarios;

namespace IncapSys.Interfaces.Usuarios
{
    public interface IUsuarioService : IBaseInterface<Empleados>
    {
        Task<Response<bool>> ExisteUsuario(int idUsuario);
        Task<Response<Empleados>> CreateAt(UsuarioAddDto model);
        Task<Response<Empleados>> Actualizar(UsuarioUpdateDto model);
        Task<UsuarioLoginDto> VerifyUser(UsuarioLoginDto login);


    }
}
