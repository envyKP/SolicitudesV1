using Microsoft.AspNetCore.Mvc;
using Transacciones.API.Aplicacion.Interfaces.Iservicio;
using Transacciones.API.Entidades.DTOs;

using System.Security.Claims;


namespace Transacciones.API.Controllers
{
    public class UsuarioController : Controller
    {


        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }


        [HttpGet("usuario/{id}")]
        public async Task<ActionResult<usuarioDTO>> GetUsuarioPorId(int id)
        {
            try
            {
                // Obtener claims del JWT (nombre, rol, etc.)
                var userClaims = HttpContext.User.Identity as ClaimsIdentity;

                if (userClaims != null && userClaims.IsAuthenticated)
                {
                    var nombre = userClaims.FindFirst("nombre")?.Value;
                    var rol = userClaims.FindFirst("rol")?.Value;

                    Console.WriteLine($"Nombre desde token: {nombre}");
                    Console.WriteLine($"Rol desde token: {rol}");
                }


                var usuario = await _usuarioService.GetUsuarioRepositorio(id);
                return Ok(usuario);

            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { mensaje = ex.Message });
            }
        }

    }
}
