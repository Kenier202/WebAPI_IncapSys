using AutoMapper;
using IncapSys.DTOs.Incapacidades;
using IncapSys.Interfaces.Incapacidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static IncapSys.ViewModels.Incapacidades.AgregarIncapacidad;

namespace IncapSys.Controllers.Incapacidades
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncapacidadesController : ControllerBase
    {
        private readonly IIncapacidadesService _incapacidadesService;
        public readonly IMapper _MappingUsuarios;

        public IncapacidadesController(IIncapacidadesService incapacidadesService, IMapper mappingUsuarios)
        {
            this._incapacidadesService = incapacidadesService;
            this._MappingUsuarios = mappingUsuarios;

        }

        [HttpPost]
        //public async Task<IActionResult> CreateAt(IncapacidadesAddDto AddIncapacidad)
        public async Task<IActionResult> CreateAt([FromBody] AgregarIncapacidadViewModel AddIncapacidad)
        {
            var incapacidad = _MappingUsuarios.Map<IncapacidadesAddDto>(AddIncapacidad);
            var response = await _incapacidadesService.CreateAt(incapacidad);

            if (response.IsSucces)
            {
                return CreatedAtAction(nameof(GetById), new {id = response.Result.Id}, response);
            }
            return StatusCode(StatusCodes.Status400BadRequest, response);

        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _incapacidadesService.Delete(id);
            if (response.IsSucces)
            {
                return StatusCode(StatusCodes.Status200OK, response);
            }
            return StatusCode(StatusCodes.Status400BadRequest, response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _incapacidadesService.getAll();
            if (response.IsSucces)
            {
                return StatusCode(StatusCodes.Status200OK, response);
            }
            return StatusCode(StatusCodes.Status400BadRequest, response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _incapacidadesService.GetById(id);
            if (response.IsSucces)
            {
                return StatusCode(StatusCodes.Status200OK, response);
            }
            return StatusCode(StatusCodes.Status400BadRequest, response);
        }

        [HttpPatch]
        public async Task<IActionResult> UpdateAt(IncapacidadesUpdateDto UpdateIncapacidad)
        {
            var response = await _incapacidadesService.Actualizar(UpdateIncapacidad);
            if (response.IsSucces)
            {
                return StatusCode(StatusCodes.Status202Accepted, response);
            }
            return StatusCode(StatusCodes.Status400BadRequest, response);
        }
    }
}
