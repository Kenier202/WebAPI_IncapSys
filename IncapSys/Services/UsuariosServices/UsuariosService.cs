﻿using IncapSys.DTOs.Usuarios;
using IncapSys.Helpers;
using IncapSys.Interfaces.Usuarios;
using IncapSys.Models.Usuarios;
using IncapSys.Repositories;

namespace IncapSys.Services.UsuariosServices
{
    public class UsuariosService : IUsuarioService
    {
        private readonly IUsuariosRepository<Empleados> _repositoryService;
        public UsuariosService(IUsuariosRepository<Empleados> _UsuariosRepository)
        {
            this._repositoryService = _UsuariosRepository;
        }

        public Task<Response<Empleados>> Actualizar(UsuarioAddDto model)
        {
            throw new NotImplementedException();
        }

        async public Task<Response<Empleados>> CreateAt(UsuarioAddDto model)
        {
            var Usuario = new Empleados() {
                Usuario = model.Usuario,
                Contraseña = model.Contraseña,
                FechaRegistro = DateTime.Now,
                RolId = model.RolId,

            };
            var NewUsuario = await _repositoryService.AddUsuario(Usuario);

            if (NewUsuario == null) return new Response<Empleados>
            {
                IsSucces = NewUsuario!.IsSucces,
                Message = NewUsuario.Message,
                Result = NewUsuario.Result
            };

            return new Response<Empleados>
            {
                IsSucces = NewUsuario.IsSucces,
                Message = NewUsuario.Message,
                Result = NewUsuario.Result
            };
        }

        async public Task<Response<Empleados>> Delete(int id)
        {
            try
            {
                var usuario = await _repositoryService.DeleteUsuario(id);

                if (usuario == null) return new Response<Empleados>
                {
                    IsSucces = usuario.IsSucces,
                    Message = usuario.Message,
                    Result = usuario.Result
                };

                return new Response<Empleados>
                {
                    IsSucces = usuario.IsSucces,
                    Message = usuario.Message,
                    Result = usuario.Result
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

        public Task<Response<bool>> ExisteUsuario(int idUsuario)
        {
            throw new NotImplementedException();
        }

        async public Task<Response<IEnumerable<Empleados>>> getAll()
        {
            var _usuariosResponse = await _repositoryService.GetAllUsuarios();

            if (_usuariosResponse == null) return new Response<IEnumerable<Empleados>>
            {
                Message = _usuariosResponse.Message,
                Result = _usuariosResponse.Result,
                IsSucces = _usuariosResponse.IsSucces
            };

            return new Response<IEnumerable<Empleados>>
            {
                IsSucces = _usuariosResponse != null,
                Message = _usuariosResponse != null ? "Se han encontrado usuarios" : "No hay resultados",
                Result = _usuariosResponse!.Result
            };
        }

        async public Task<Response<Empleados>> GetById(int id)
        {
            var _usuariosResponse = await _repositoryService.GetUsuarioById(id);

            if (_usuariosResponse == null) return new Response<Empleados>
            {
                Message = "Usuario no encontrado",
                Result = null,
                IsSucces = false
            };


            return new Response<Empleados>
            {
                IsSucces = true,
                Message = "usuario encontrado",
                Result = _usuariosResponse.Result,
            };
        }
    }
}