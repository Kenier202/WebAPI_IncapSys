using IncapSys.DTOs.Incapacidades;
using IncapSys.Interfaces.Incapacidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IncapSys.Controllers.Incapacidades
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncapacidadesController : ControllerBase
    {
        private readonly IIncapacidadesService _incapacidadesService;
        public IncapacidadesController(IIncapacidadesService incapacidadesService) {
            this._incapacidadesService = incapacidadesService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAt(IncapacidadesAddDto AddIncapacidad)
        {
            var response = await _incapacidadesService.CreateAt(AddIncapacidad);
            if (response.IsSucces)
            {
                return StatusCode(StatusCodes.Status200OK, response);
            }
            return StatusCode(StatusCodes.Status204NoContent, response);

        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _incapacidadesService.Delete(id);
            if (response.IsSucces)
            {
                return StatusCode(StatusCodes.Status200OK, response);
            }
            return StatusCode(StatusCodes.Status204NoContent, response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _incapacidadesService.getAll();
            if (response.IsSucces)
            {
                return StatusCode(StatusCodes.Status200OK, response);
            }
            return StatusCode(StatusCodes.Status204NoContent, response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById( int id )
        {
            var response = await _incapacidadesService.GetById( id );
            if (response.IsSucces)
            {
                return StatusCode(StatusCodes.Status200OK, response);
            }
            return StatusCode(StatusCodes.Status204NoContent, response);
        }
    }
}
