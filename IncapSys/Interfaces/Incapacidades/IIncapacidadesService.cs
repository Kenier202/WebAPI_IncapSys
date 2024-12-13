using IncapSys.DTOs.Incapacidades;
using IncapSys.DTOs.Usuarios;
using IncapSys.Helpers;
using IncapSys.Models.Incapacidades;
using IncapSys.Models.Usuarios;

namespace IncapSys.Interfaces.Incapacidades
{
    public interface IIncapacidadesService : IBaseInterface<IncapacidadesDto>
    {
        Task<Response<bool>> ExisteIncapacidad(int idUsuario);
        public Task<Response<IncapacidadesDto>> CreateAt(IncapacidadesAddDto model);
        public Task<Response<IncapacidadesDto>> Actualizar(IncapacidadesUpdateDto model);
    }
}
