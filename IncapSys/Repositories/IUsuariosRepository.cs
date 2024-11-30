namespace IncapSys.Repositories
{
    public interface IUsuariosRepository<T>
    {
        public Task<IEnumerable<T>> GetAllUsuarios();
        public Task<T> GetUsuarioById(int id);
        public Task<T> AddUsuario(T incapacidad);
        public Task<T> DeleteUsuario(int id);
        public Task<T> UpdateUsuario(T incapacidad);
        public Task Save();
    }
}
