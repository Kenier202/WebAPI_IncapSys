using IncapSys.Helpers;
using IncapSys.Models;
using IncapSys.Models.Usuarios;
using IncapSys.Repositories;
using Microsoft.EntityFrameworkCore;

namespace IncapSys.Services.UsuariosServices
{
    public class UsuarioRepositoryService : IUsuariosRepository<Empleados>
    {
        private readonly ApplicationDbContext _DbContext;
        public UsuarioRepositoryService(ApplicationDbContext _DbContext) {
            this._DbContext = _DbContext;
        }

        async Task<Response<IEnumerable<Empleados>>> IUsuariosRepository<Empleados>.GetAllUsuarios()
        {
            var usuarios = await _DbContext.Usuarios
                                          .Include(e => e.Rol)  // Asegúrate de incluir el rol
                                          .Include(e => e.Incapacidades)  // Si también necesitas incluir las incapacidades
                                          .ToListAsync();

            if (usuarios == null) return null;

            return new Response<IEnumerable<Empleados>> { 
                IsSucces = usuarios.Any(),
                Message = usuarios.Any() ? "Usuarios encontrados" : "Usuarios no encontrados",
                Result = usuarios
            };
        }

        async Task<Response<Empleados>> IUsuariosRepository<Empleados>.GetUsuarioById(int id)
        {
            var usuarios = await _DbContext.Usuarios.FindAsync(id);

            if (usuarios == null) return null;

            return new Response<Empleados>
            {   
                IsSucces = true,
                Message = "Usuario encontrado",
                Result = usuarios,
            };

        }

        async Task<Response<Empleados>> IUsuariosRepository<Empleados>.AddUsuario(Empleados usuario)
        {
            if (usuario == null) return new Response<Empleados> {
                IsSucces = false,
                Message = "Los datos enviados son erroneos",
                Result = null,
            };

            var usuarios = await _DbContext.AddAsync(usuario);
            await _DbContext.SaveChangesAsync();

            return new Response<Empleados>{
             IsSucces = true,
             Message = "Usuario registrado con exito",
             Result = usuario
            };
        }


        Task<Response<Empleados>> IUsuariosRepository<Empleados>.DeleteUsuario(int id)
        {
            throw new NotImplementedException();
        }



        Task<Response<Empleados>> IUsuariosRepository<Empleados>.UpdateUsuario(Empleados incapacidad)
        {
            throw new NotImplementedException();
        }
    
    }
}
