using AutoMapper;
using IncapSys.Helpers;
using IncapSys.Models;
using IncapSys.Models.Incapacidades;
using IncapSys.Models.Usuarios;
using IncapSys.Repositories.Incapacidades;
using System.Data.Common;

namespace IncapSys.Services.IncapacidadesServices
{
    public class IncapacidadesRepositoryService : IIncapacidadesRepository<DescripcionIncapacidad>
    {
        private readonly ApplicationDbContext _DbContext;

        public IncapacidadesRepositoryService(
            ApplicationDbContext aplicationDbContext
            )
        {
            this._DbContext = aplicationDbContext;
        }

        public async Task<Response<DescripcionIncapacidad>> AddIncapacidad(DescripcionIncapacidad incapacidad)
        {
            if ( incapacidad == null ) return new Response<DescripcionIncapacidad>
            {
                IsSucces = false,
                Message  = "Faltan datos",
                Result   = null
            };

            try
            {
                await _DbContext.AddAsync( incapacidad );
                var result = await _DbContext.SaveChangesAsync();

                if (result < 0) return new Response<DescripcionIncapacidad>
                {
                    IsSucces = false,
                    Message = "Fallo al insertar",
                    Result = null
                };

                return new Response<DescripcionIncapacidad> 
                {
                    IsSucces = true,
                    Message  = "Incapacidad registrada con exito",
                    Result   = incapacidad
                };
            }
            catch (DbException dbEx)
            {
                return new Response<DescripcionIncapacidad> 
                {
                    IsSucces = false,
                    Message  = dbEx.Message,
                    Result   = null
                };
            }
            catch (Exception ex) 
            {
                return new Response<DescripcionIncapacidad>
                {
                    IsSucces = false,
                    Message = ex.Message,
                    Result = null
                };
            }
        }

        public Task<Response<DescripcionIncapacidad>> DeleteIncapacidad(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<DescripcionIncapacidad>> GetAllIncapacidades()
        {
            throw new NotImplementedException();
        }

        public Task<Response<DescripcionIncapacidad>> GetIncapacidadesById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Response<DescripcionIncapacidad>> UpdateIncapacidad(DescripcionIncapacidad incapacidad)
        {
            throw new NotImplementedException();
        }
    }
}
