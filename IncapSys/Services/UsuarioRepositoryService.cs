using IncapSys.Models.Usuarios;
using IncapSys.Repositories;

namespace IncapSys.Services
{
    public class UsuarioRepositoryService : IUsuariosRepository<Empleados>
    {
        Task<Empleados> IUsuariosRepository<Empleados>.AddUsuario(Empleados incapacidad)
        {
            throw new NotImplementedException();
        }

        Task<Empleados> IUsuariosRepository<Empleados>.DeleteUsuario(int id)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Empleados>> IUsuariosRepository<Empleados>.GetAllUsuarios()
        {
            throw new NotImplementedException();
        }

        Task<Empleados> IUsuariosRepository<Empleados>.GetUsuarioById(int id)
        {
            throw new NotImplementedException();
        }

        Task IUsuariosRepository<Empleados>.Save()
        {
            throw new NotImplementedException();
        }

        Task<Empleados> IUsuariosRepository<Empleados>.UpdateUsuario(Empleados incapacidad)
        {
            throw new NotImplementedException();
        }
    }
}
