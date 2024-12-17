using AutoMapper;
using IncapSys.DTOs.Usuarios;
using IncapSys.Interfaces.Usuarios;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace IncapSys.Controllers.Usuarios.Login
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUsuarioService _UsuarioService;
        private readonly IConfiguration _Configuration;
        public LoginController(IUsuarioService UsuariosService, IConfiguration configuration)
        {
            _Configuration = configuration;
            _UsuarioService = UsuariosService;
        }

        [HttpPost("Authenticate")]
        public async Task<IActionResult> Login(UsuarioLoginDto LoginDto)
        {
            var result = await _UsuarioService.VerifyUser(LoginDto);

            if (result == null) return BadRequest(new { message = "Credenciales invalidas" });

            string jwtToken = GenerateToken(result);

            return Ok(new { token = jwtToken });
        }
        private string GenerateToken(UsuarioLoginDto user)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.Usuario),
                new Claim(ClaimTypes.Role, user.RolId.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_Configuration.GetSection("JWT:Key").Value));
            var credencials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

            var securityToken = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(20),
                    signingCredentials: credencials
                );

            string token = new JwtSecurityTokenHandler().WriteToken(securityToken);

            return token;
        }
    }
}
