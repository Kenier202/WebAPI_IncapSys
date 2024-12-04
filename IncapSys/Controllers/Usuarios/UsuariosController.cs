using AutoMapper;
using IncapSys.DTOs.Usuarios;
using IncapSys.Interfaces.Usuarios;
using IncapSys.Models.Usuarios;
using IncapSys.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace IncapSys.Controllers.Usuarios
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        public readonly IUsuarioService _UsuarioService;
        public readonly IMapper _MappingUsuarios;
        public UsuariosController(IUsuarioService _usuarios, IMapper mappingUsuarios)
        {
            _UsuarioService = _usuarios;
            _MappingUsuarios = mappingUsuarios;
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
        async public Task<IActionResult> CreateAt([FromBody] AgregarUsuario usuario)
        {
            var UsuarioDto = _MappingUsuarios.Map<UsuarioAddDto>(usuario);

            var response = await _UsuarioService.CreateAt(UsuarioDto);
            if (response.IsSucces)
            {
                return StatusCode(StatusCodes.Status200OK, response);
            }
            return StatusCode(StatusCodes.Status404NotFound, response);
        }

        [HttpDelete("{id}")]
        async public Task<IActionResult> DeleteUsuario( int id)
        {
            try
            {
                var response = await _UsuarioService.Delete(id);

                if (!response.IsSucces) {
                    return StatusCode(StatusCodes.Status200OK, response);
                }
                return StatusCode(StatusCodes.Status404NotFound, response);
            }
            catch (Exception ex) {
                return StatusCode(StatusCodes.Status404NotFound);
            }
        }

    }
}
