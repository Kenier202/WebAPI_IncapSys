using IncapSys.Interfaces.Usuarios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IncapSys.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        public readonly IUsuarioService _UsuarioService;
        public UsuariosController(IUsuarioService _usuarios) {
            this._UsuarioService = _usuarios;
        }
        [HttpGet]
        async public Task<IActionResult> GetAll() {
            var response = await _UsuarioService.getAll();
            if (response.IsSucces)
            {
                return StatusCode(StatusCodes.Status200OK, response);
            }
            return StatusCode(StatusCodes.Status204NoContent, response);

        }
    }
}
