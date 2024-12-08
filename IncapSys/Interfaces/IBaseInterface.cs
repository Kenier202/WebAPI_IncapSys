using IncapSys.Helpers;

namespace IncapSys.Interfaces
{
    public interface IBaseInterface<T>
    {
        //get all incapacidades
        public Task<Response<IEnumerable<T>>> getAll();
        public Task<Response<T>> GetById(int id);
        public Task<Response<T>> Delete(int id);
    }
}
