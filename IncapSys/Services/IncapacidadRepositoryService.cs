using IncapSys.Models.Incapacidades;
using IncapSys.Repositories;

namespace IncapSys.Services
{
    public class IncapacidadRepositoryService : IIncapacidadesRepository<DescripcionIncapacidad>
    {
        Task<DescripcionIncapacidad> IIncapacidadesRepository<DescripcionIncapacidad>.AddIncapacidad(DescripcionIncapacidad incapacidad)
        {
            throw new NotImplementedException();
        }

        Task<DescripcionIncapacidad> IIncapacidadesRepository<DescripcionIncapacidad>.DeleteIncapacidad(int id)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<DescripcionIncapacidad>> IIncapacidadesRepository<DescripcionIncapacidad>.GetAllIncapacidades()
        {
            throw new NotImplementedException();
        }

        Task<DescripcionIncapacidad> IIncapacidadesRepository<DescripcionIncapacidad>.GetIncapacidadesById(int id)
        {
            throw new NotImplementedException();
        }

        Task IIncapacidadesRepository<DescripcionIncapacidad>.Save()
        {
            throw new NotImplementedException();
        }

        Task<DescripcionIncapacidad> IIncapacidadesRepository<DescripcionIncapacidad>.UpdateIncapacidad(DescripcionIncapacidad incapacidad)
        {
            throw new NotImplementedException();
        }
    }
}
