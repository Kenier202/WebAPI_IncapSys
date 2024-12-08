using IncapSys.DTOs.Rol;
using IncapSys.DTOs.Usuarios;
using IncapSys.Helpers;
using IncapSys.Models.Rol;
using IncapSys.Models.Usuarios;

namespace IncapSys.Interfaces.Rol
{
    public interface IRolService : IBaseInterface<Roles>
    {
        Task<Response<bool>> ExisteRol(int idUsuario);
        Task<Response<Empleados>> CreateAt(RolAddDto model);
        Task<Response<Empleados>> Actualizar(RolUpdateDto model);
    }
}
