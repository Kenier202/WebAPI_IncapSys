using AutoMapper;
using IncapSys.DTOs.Incapacidades;
using IncapSys.Helpers;
using IncapSys.Models;
using IncapSys.Models.Incapacidades;
using IncapSys.Repositories.Incapacidades;
using Microsoft.EntityFrameworkCore;
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
            if (incapacidad == null) return new Response<DescripcionIncapacidad>
            {
                IsSucces = false,
                Message = "Faltan datos",
                Result = null
            };

            try
            {
                await _DbContext.AddAsync(incapacidad);
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
                    Message = "Incapacidad registrada con exito",
                    Result = incapacidad
                };
            }
            catch (DbException dbEx)
            {
                return new Response<DescripcionIncapacidad>
                {
                    IsSucces = false,
                    Message = dbEx.Message,
                    Result = null
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

        public async Task<Response<DescripcionIncapacidad>> DeleteIncapacidad(int id)
        {
            var incapacidad = await _DbContext.Incapacidades.FindAsync(id);

            if (incapacidad == null) return new Response<DescripcionIncapacidad>
            {
                IsSucces = false,
                Message = "Rellene los datos",
                Result = null
            };

            try
            {
                _DbContext.Remove(incapacidad);
                var result = await _DbContext.SaveChangesAsync();

                if (result < 0) return new Response<DescripcionIncapacidad>
                {
                    IsSucces = false,
                    Message = "Incapacidad no encontrada",
                    Result = null
                };

                return new Response<DescripcionIncapacidad>
                {
                    IsSucces = true,
                    Message = "Incapacidad eliminada",
                    Result = incapacidad
                };
            }
            catch (DbException dbEx)
            {
                return new Response<DescripcionIncapacidad>
                {
                    IsSucces = false,
                    Message = dbEx.Message,
                    Result = null
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

        public async Task<Response<IEnumerable<DescripcionIncapacidad>>> GetAllIncapacidades()
        {
            try
            {
                var incapacidades = await _DbContext.Incapacidades.Include(u => u.Usuario).ToListAsync();

                if (incapacidades == null) return new Response<IEnumerable<DescripcionIncapacidad>>
                {
                    IsSucces = false,
                    Message = "Incapacidades no encontradas",
                    Result = null
                };

                return new Response<IEnumerable<DescripcionIncapacidad>>
                {
                    IsSucces = true,
                    Message = "Incapacidades encontradas",
                    Result = incapacidades
                };
            }
            catch (Exception ex)
            {
                return new Response<IEnumerable<DescripcionIncapacidad>>
                {
                    IsSucces = false,
                    Message = ex.Message,
                    Result = null
                };
            }
        }

        public async Task<Response<DescripcionIncapacidad>> GetIncapacidadesById(int id)
        {
            try
            {
                var incapacidad = await _DbContext.Incapacidades
                                                    .Include(u => u.Usuario.Usuario)
                                                    .FirstOrDefaultAsync(i => i.Id == id);

                if (incapacidad == null) return new Response<DescripcionIncapacidad>
                {
                    IsSucces = false,
                    Message = "No se encontro incapacidad",
                    Result = null
                };

                return new Response<DescripcionIncapacidad>
                {
                    IsSucces = true,
                    Message = "Incapacidad encontrada",
                    Result = incapacidad
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

        public async Task<Response<DescripcionIncapacidad>> UpdateIncapacidad(DescripcionIncapacidad incapacidad)
        {
            if (incapacidad == null) return new Response<DescripcionIncapacidad>
            {
                IsSucces = false,
                Message = "Rellene los datos",
                Result = null
            };

            try
            {
                // Verifica si la entidad ya existe en la base de datos.
                var existingIncapacidad = await _DbContext.Incapacidades
                    .FirstOrDefaultAsync(i => i.Id == incapacidad.Id);

                if (existingIncapacidad == null)
                {
                    return new Response<DescripcionIncapacidad>
                    {
                        IsSucces = false,
                        Message = "Incapacidad no encontrada.",
                        Result = null
                    };
                }

                // Si existe, actualiza los valores de la entidad.
                _DbContext.Entry(existingIncapacidad).CurrentValues.SetValues(incapacidad);
                _DbContext.Entry(existingIncapacidad).State = EntityState.Modified;

                var result = await _DbContext.SaveChangesAsync();

                if (result < 0)
                {
                    return new Response<DescripcionIncapacidad>
                    {
                        IsSucces = false,
                        Message = "Error al guardar",
                        Result = null
                    };
                }

                return new Response<DescripcionIncapacidad>
                {
                    IsSucces = true,
                    Message = "Incapacidad actualizada",
                    Result = existingIncapacidad
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

    }
}
