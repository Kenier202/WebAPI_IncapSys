using IncapSys.Helpers;
using IncapSys.Interfaces;
using IncapSys.Interfaces.Incapacidades;
using IncapSys.Models.Incapacidades;

namespace IncapSys.Services
{
    public class IncapacidadesService : IIncapacidadesService
    {
        Task<Response<DescripcionIncapacidad>> IBaseInterface<DescripcionIncapacidad>.Actualizar(DescripcionIncapacidad model)
        {
            throw new NotImplementedException();
        }

        Task<Response<DescripcionIncapacidad>> IBaseInterface<DescripcionIncapacidad>.CreateAt(DescripcionIncapacidad model)
        {
            throw new NotImplementedException();
        }

        Task<Response<DescripcionIncapacidad>> IBaseInterface<DescripcionIncapacidad>.Delete(int id)
        {
            throw new NotImplementedException();
        }

        Task<Response<IEnumerable<DescripcionIncapacidad>>> IBaseInterface<DescripcionIncapacidad>.getAll()
        {
            throw new NotImplementedException();
        }

        Task<Response<DescripcionIncapacidad>> IBaseInterface<DescripcionIncapacidad>.GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
