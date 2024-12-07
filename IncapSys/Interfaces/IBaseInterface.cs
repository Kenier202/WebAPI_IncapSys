using IncapSys.Helpers;

namespace IncapSys.Interfaces
{
    public interface IBaseInterface<T, TDto, UUDto>
    {
        //get all incapacidades
        public Task<Response<IEnumerable<T>>> getAll();
        public Task<Response<T>> GetById(int id);
        //all get one incapacidad
        public Task<Response<T>> CreateAt(TDto model);
        public Task<Response<T>> Actualizar(UUDto model);
        public Task<Response<T>> Delete(int id);
    }
}
