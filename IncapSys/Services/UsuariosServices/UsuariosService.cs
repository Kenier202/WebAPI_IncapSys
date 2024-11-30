using IncapSys.Helpers;
using IncapSys.Interfaces;
using IncapSys.Interfaces.Usuarios;
using IncapSys.Models.Usuarios;
using IncapSys.Repositories;

namespace IncapSys.Services.UsuariosServices
{
    public class UsuariosService : IUsuarioService
    {
        private readonly IUsuariosRepository<Empleados> _repositoryService;
        public UsuariosService(IUsuariosRepository<Empleados> _UsuariosRepository) {
            this._repositoryService = _UsuariosRepository;
        }

        async Task<Response<IEnumerable<Empleados>>> IBaseInterface<Empleados>.getAll()
        {
            var _usuariosResponse = await _repositoryService.GetAllUsuarios();

            if (_usuariosResponse == null) return new Response<IEnumerable<Empleados>>
            {
                Message = "Usuarios no encontrados",
                Result = null,
                IsSucces = false
            };

            return new Response<IEnumerable<Empleados>>
            {
                IsSucces = _usuariosResponse != null,
                Message = _usuariosResponse != null ? "Se han encontrado usuarios" : "No hay resultados",
                Result = _usuariosResponse.Result
            };
        }

        async Task<Response<Empleados>> IBaseInterface<Empleados>.GetById(int id)
        {
            var _usuariosResponse = await _repositoryService.GetUsuarioById(id);

            if (_usuariosResponse == null) return new Response<Empleados> {
                Message = "Usuario no encontrado",
                Result = null,
                IsSucces = false
            };


            return new Response<Empleados> {
                IsSucces = true,
                Message = "usuario encontrado",
                Result = _usuariosResponse.Result,
            };
        }

        async Task<Response<Empleados>> IBaseInterface<Empleados>.Actualizar(Empleados model)
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


    }
}
