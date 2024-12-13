using IncapSys.Helpers;

namespace IncapSys.Repositories.Incapacidades
{
    public interface IIncapacidadesRepository<T>
    {
        public Task<IEnumerable<T>> GetAllIncapacidades();
        public Task<Response<T>> GetIncapacidadesById(int id);
        public Task<Response<T>> AddIncapacidad(T incapacidad);
        public Task<Response<T>> DeleteIncapacidad(int id);
        public Task<Response<T>> UpdateIncapacidad(T incapacidad);

    }
}
