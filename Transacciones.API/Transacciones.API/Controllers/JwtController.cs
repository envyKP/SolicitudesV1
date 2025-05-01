using Microsoft.AspNetCore.Mvc;
using Transacciones.API.Aplicacion.Servicios;
using Transacciones.API.Entidades.DTOs;

namespace Transacciones.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class JwtController : Controller
    {

        private readonly JwtTokenService _jwtTokenService;
        public JwtController()
        {
            _jwtTokenService = new JwtTokenService();  // Inicializamos el servicio de token
        }


        [HttpPost("generate")]
        public IActionResult GenerateToken([FromBody] usuarioDTO usuarioDto)
        {
            if (usuarioDto == null || string.IsNullOrEmpty(usuarioDto.Nombre) || string.IsNullOrEmpty(usuarioDto.Rol))
            {
                return BadRequest("Datos de usuario no válidos");
            }

            var token = _jwtTokenService.GenerateJwtToken(usuarioDto.Idusuario, usuarioDto.Nombre, usuarioDto.Rol);
            return Ok(new { Token = token });
        }


    }
}
