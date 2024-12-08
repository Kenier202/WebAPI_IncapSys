namespace IncapSys.Repositories.Incapacidades
{
    public interface IIncapacidadesRepository<T>
    {
        public Task<IEnumerable<T>> GetAllIncapacidades();
        public Task<T> GetIncapacidadesById(int id);
        public Task<T> AddIncapacidad(T incapacidad);
        public Task<T> DeleteIncapacidad(int id);
        public Task<T> UpdateIncapacidad(T incapacidad);
        public Task Save();

    }
}
