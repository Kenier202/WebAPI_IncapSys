﻿using IncapSys.DTOs.Incapacidades;
using IncapSys.DTOs.Usuarios;
using IncapSys.Helpers;
using IncapSys.Models.Incapacidades;
using IncapSys.Models.Usuarios;

namespace IncapSys.Interfaces.Incapacidades
{
    public interface IIncapacidadesService : IBaseInterface<Empleados>
    {
        Task<Response<bool>> ExisteIncapacidad(int idUsuario);
        public Task<Response<Empleados>> CreateAt(IncapacidadesAddDto model);
        public Task<Response<Empleados>> Actualizar(IncapacidadesUpdateDto model);
    }
}
