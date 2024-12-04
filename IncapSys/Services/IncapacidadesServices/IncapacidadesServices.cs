using IncapSys.DTOs.Usuarios;
using IncapSys.Helpers;
using IncapSys.Interfaces;
using IncapSys.Interfaces.Incapacidades;
using IncapSys.Models.Incapacidades;

namespace IncapSys.Services.IncapacidadesServices
{
    public class IncapacidadesServices : IIncapacidadesService
    {
        public Task<Response<DescripcionIncapacidad>> Actualizar(UsuarioAddDTO model)
        {
            throw new NotImplementedException();
        }

        public Task<Response<DescripcionIncapacidad>> CreateAt(UsuarioAddDTO model)
        {
            throw new NotImplementedException();
        }

        public Task<Response<DescripcionIncapacidad>> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Response<IEnumerable<DescripcionIncapacidad>>> getAll()
        {
            throw new NotImplementedException();
        }

        public Task<Response<DescripcionIncapacidad>> GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
