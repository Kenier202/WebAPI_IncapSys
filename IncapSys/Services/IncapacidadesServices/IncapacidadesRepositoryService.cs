using IncapSys.Models.Incapacidades;
using IncapSys.Models.Usuarios;
using IncapSys.Repositories;

namespace IncapSys.Services.IncapacidadesServices
{
    public class IncapacidadesRepositoryService : IIncapacidadesRepository<DescripcionIncapacidad>
    {
        public Task<DescripcionIncapacidad> AddIncapacidad(DescripcionIncapacidad incapacidad)
        {
            throw new NotImplementedException();
        }

        public Task<DescripcionIncapacidad> DeleteIncapacidad(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<DescripcionIncapacidad>> GetAllIncapacidades()
        {
            throw new NotImplementedException();
        }

        public Task<DescripcionIncapacidad> GetIncapacidadesById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Save()
        {
            throw new NotImplementedException();
        }

        public Task<DescripcionIncapacidad> UpdateIncapacidad(DescripcionIncapacidad incapacidad)
        {
            throw new NotImplementedException();
        }
    }
}
