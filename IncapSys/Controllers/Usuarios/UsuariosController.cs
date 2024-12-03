using IncapSys.DTOs.Usuarios;
using IncapSys.Interfaces.Usuarios;
using IncapSys.Models.Usuarios;
using Microsoft.AspNetCore.Mvc;

namespace IncapSys.Controllers.Usuarios
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        public readonly IUsuarioService _UsuarioService;
        public UsuariosController(IUsuarioService _usuarios)
        {
            _UsuarioService = _usuarios;
        }
        [HttpGet]
        async public Task<IActionResult> GetAll()
        {
            var response = await _UsuarioService.getAll();
            if (response.IsSucces)
            {
                return StatusCode(StatusCodes.Status200OK, response);
            }
            return StatusCode(StatusCodes.Status204NoContent, response);

        }

        [HttpGet("{id}")]
        async public Task<IActionResult> GetUsersById(int id)
        {
            var response = await _UsuarioService.GetById(id);
            if (response.IsSucces)
            {
                return StatusCode(StatusCodes.Status200OK, response);
            }
            return StatusCode(StatusCodes.Status404NotFound, response);
        }

        [HttpPost]
        async public Task<IActionResult> CreateAt(UsuarioAddDTO usuario)
        {
            var response = await _UsuarioService.CreateAt(usuario);
            if (response.IsSucces)
            {
                return StatusCode(StatusCodes.Status200OK, response);
            }
            return StatusCode(StatusCodes.Status404NotFound, response);
        }
    }
}
