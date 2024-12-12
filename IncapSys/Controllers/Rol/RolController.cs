using IncapSys.DTOs.Rol;
using IncapSys.Interfaces.Rol;
using IncapSys.Services.RolServices;
using Microsoft.AspNetCore.Mvc;

namespace IncapSys.Controllers.Rol
{
    [Route("usuarios/[controller]")]
    [ApiController]
    public class RolController : ControllerBase
    {
        private readonly IRolService _rolService;
        public RolController(IRolService rolService) {
            _rolService = rolService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _rolService.getAll();
            if (response.IsSucces)
            {
                return StatusCode(StatusCodes.Status200OK, response);
            }
            return StatusCode(StatusCodes.Status204NoContent, response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _rolService.GetById(id);
            if (response.IsSucces)
            {
                return StatusCode(StatusCodes.Status200OK, response);
            }
            return StatusCode(StatusCodes.Status404NotFound,response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAt(RolAddDto rolAdd) {
        
            var response = await _rolService.CreateAt(rolAdd);
            if (response.IsSucces)
            {
                return StatusCode(StatusCodes.Status200OK, response);
            }
            return StatusCode(StatusCodes.Status404NotFound, response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById(int id)
        {
            var response = await _rolService.Delete(id);
            if (response.IsSucces)
            {
                return StatusCode(StatusCodes.Status200OK, response);
            }
            return StatusCode(StatusCodes.Status404NotFound, response);
        }
    }
}
