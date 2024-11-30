using IncapSys.Helpers;
using IncapSys.Interfaces;
using IncapSys.Interfaces.Usuarios;
using IncapSys.Models.Usuarios;

namespace IncapSys.Services
{
    public class UsuariosService : IUsuarioService
    {
        Task<Response<Empleados>> IBaseInterface<Empleados>.Actualizar(Empleados model)
        {
            throw new NotImplementedException();
        }

        Task<Response<Empleados>> IBaseInterface<Empleados>.CreateAt(Empleados model)
        {
            throw new NotImplementedException();
        }

        Task<Response<Empleados>> IBaseInterface<Empleados>.Delete(int id)
        {
            throw new NotImplementedException();
        }

        Task<Response<bool>> IUsuarioService.ExisteUsuario(int idUsuario)
        {
            throw new NotImplementedException();
        }

        Task<Response<IEnumerable<Empleados>>> IBaseInterface<Empleados>.getAll()
        {
            throw new NotImplementedException();
        }

        Task<Response<Empleados>> IBaseInterface<Empleados>.GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
