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

        public Task<Response<Empleados>> Actualizar(UsuarioAddDTO model)
        {
            throw new NotImplementedException();
        }

        async public Task<Response<Empleados>> CreateAt(UsuarioAddDTO model)
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
                IsSucces = NewUsuario.IsSucces,
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

        public Task<Response<Empleados>> Delete(int id)
        {
            throw new NotImplementedException();
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