using AutoMapper;
using IncapSys.DTOs.Usuarios;
using IncapSys.Interfaces.Usuarios;
using IncapSys.ViewModels.Usuarios;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace IncapSys.Controllers.Usuarios
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioService _UsuarioService;
        private readonly IMapper _MappingUsuarios;
        private IConfiguration _Configuration;
        public UsuariosController(IUsuarioService _usuarios, IMapper mappingUsuarios, IConfiguration configuration)
        {
            _UsuarioService = _usuarios;
            _MappingUsuarios = mappingUsuarios;
            _Configuration = configuration;
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
        async public Task<IActionResult> GetById(int id)
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
                return CreatedAtAction(nameof(GetById), new {Id = response.Result.Id}, response);
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

        [HttpPut]
        async public Task<IActionResult> UpdateUsuario([FromBody] ActualizarUsuario usuario)
        {
            var UsuarioDto = _MappingUsuarios.Map<UsuarioUpdateDto>(usuario);
            var response = await  _UsuarioService.Actualizar(UsuarioDto);
         
            if (response.IsSucces)
            {
                return StatusCode(StatusCodes.Status200OK, response);
            }
            return StatusCode(StatusCodes.Status404NotFound, response);
        }


    }
}
 