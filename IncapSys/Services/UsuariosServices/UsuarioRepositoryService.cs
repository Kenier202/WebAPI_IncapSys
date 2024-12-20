﻿using IncapSys.DTOs.Usuarios;
using IncapSys.Helpers;
using IncapSys.Models;
using IncapSys.Models.Usuarios;
using IncapSys.Repositories.Usuarios;
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
                                          .Include(e => e.Rol)  
                                          .Include(e => e.Incapacidades) 
                                          .ToListAsync();

            if (usuarios == null || !usuarios.Any()) return new Response<IEnumerable<Empleados>>
            {
                IsSucces = false,
                Message = "Usuarios no encontrados",
                Result = usuarios
            };

            return new Response<IEnumerable<Empleados>> { 
                IsSucces = usuarios.Any(),
                Message = "Usuarios encontrados",
                Result = usuarios
            };
        }

        async Task<Response<Empleados>> IUsuariosRepository<Empleados>.GetUsuarioById(int id)
        {
            var usuarios = await _DbContext.Usuarios
                                 .Include(e => e.Rol)  
                                 .Include(e => e.Incapacidades) 
                                 .FirstOrDefaultAsync(u => u.Id == id);

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

            await _DbContext.AddAsync(usuario);
            await _DbContext.SaveChangesAsync();

            return new Response<Empleados>{
             IsSucces = true,
             Message = "Usuario registrado con exito",
             Result = usuario
            };
        }
        async Task<Response<Empleados>> IUsuariosRepository<Empleados>.UpdateUsuario(Empleados usuario)
        {
            if (usuario == null) return new Response<Empleados>
            {
                IsSucces = false,
                Message = "Los datos enviados son erroneos",
                Result = null,
            };

            try
            {
                _DbContext.Usuarios.Attach(usuario);
                _DbContext.Entry(usuario).State = EntityState.Modified;

                var result = await _DbContext.SaveChangesAsync();

                if (result < 0) return new Response<Empleados>
                {
                    IsSucces = false,
                    Message  = "No se encontraron usuarios",
                    Result   = null
                };

                return new Response<Empleados>{
                    IsSucces = true,
                    Message = "Usuario actualizado con exito",
                    Result = usuario,
                };

            }
            catch (Exception ex) {
                return new Response<Empleados>
                {
                    IsSucces = false,
                    Message = ex.Message,
                    Result = null,
                };
            }
            
        }

        async Task<Response<Empleados>> IUsuariosRepository<Empleados>.DeleteUsuario(int id)
        {
            if (id == 0) return new Response<Empleados>
            {
                IsSucces = false,
                Message = "Los datos enviados son erroneos",
                Result = null,
            };

            try
            {
                var usuario = await _DbContext.Usuarios
                                         .Include(e => e.Rol) 
                                         .Include(e => e.Incapacidades) 
                                         .FirstOrDefaultAsync(u => u.Id == id); 

                if (usuario == null)
                {
                    return new Response<Empleados> { 
                        IsSucces = false,
                        Message = "Usuario no encontrado",
                        Result = null!
                    };
                }

                _DbContext.Remove(usuario!);
                await _DbContext.SaveChangesAsync();

                return new Response<Empleados>
                {
                    IsSucces = true,
                    Message = "Usuario eliminado con exito",
                    Result = usuario,
                };

            }
            catch (Exception ex) {
                return new Response<Empleados>
                {
                   IsSucces = false,
                   Message = ex.Message,
                   Result = null
                };
            }
        }

        public async Task<UsuarioLoginDto> VerifyUser(UsuarioLoginDto login)
        {
            try
            {
                // Buscar al usuario por nombre de usuario (Usuario)
                var user = await _DbContext.Usuarios
                    .FirstOrDefaultAsync(u => u.Usuario == login.Usuario); // O el nombre de campo correspondiente en tu base de datos

                if (user == null)
                {
                    return null; // Usuario no encontrado
                }

                // Retorna si la contraseña es válida
                return new UsuarioLoginDto() {
                    Usuario = login.Usuario,
                    RolId   = login.RolId,
                }; 
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción que pueda ocurrir durante el proceso
                // Puedes registrar el error en un log o manejarlo de la manera que consideres.
                // Por ejemplo:
                Console.WriteLine($"Error al verificar el usuario: {ex.Message}");
                return null; // Retorna false si ocurre algún error
            }
        }

    }
}
