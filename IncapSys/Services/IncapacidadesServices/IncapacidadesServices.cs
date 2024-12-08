using IncapSys.DTOs.Incapacidades;
using IncapSys.DTOs.Usuarios;
using IncapSys.Helpers;
using IncapSys.Interfaces;
using IncapSys.Interfaces.Incapacidades;
using IncapSys.Models.Incapacidades;
using IncapSys.Models.Usuarios;

namespace IncapSys.Services.IncapacidadesServices
{
    public class IncapacidadesServices : IIncapacidadesService
    {
        public Task<Response<Empleados>> Actualizar(IncapacidadesUpdateDto model)
        {
            throw new NotImplementedException();
        }

        public Task<Response<Empleados>> CreateAt(IncapacidadesAddDto model)
        {
            throw new NotImplementedException();
        }

        public Task<Response<Empleados>> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Response<bool>> ExisteIncapacidad(int idUsuario)
        {
            throw new NotImplementedException();
        }

        public Task<Response<IEnumerable<Empleados>>> getAll()
        {
            throw new NotImplementedException();
        }

        public Task<Response<Empleados>> GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
