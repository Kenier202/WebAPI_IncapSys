﻿using IncapSys.Helpers;

namespace IncapSys.Services.Interfaces
{
    public interface BaseInterface<T> 
    {
        //get all incapacidades
        public Task<Response<IEnumerable<T>>> getAll();
        public Task<Response<T>> GetById(int id);
        //all get one incapacidad
        public Task<Response<T>> CreateAt (T model);
        public Task<Response<T>> Actualizar(T model);
        public Task<Response<T>> Delete (int id);
    }
}
