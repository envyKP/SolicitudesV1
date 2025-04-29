using Microsoft.AspNetCore.Mvc;
using Solicitudes.API.Aplicacion.Interfaces.IServicios;

namespace Solicitudes.API.Controllers
{
    public class UsuarioController : Controller

    {
        
        private readonly IUsuarioServicio _usuarioServicio;

        public UsuarioController(IUsuarioServicio usuarioServicio)
        {
            _usuarioServicio = usuarioServicio;
        }


        [HttpGet("detalle/{id}")]
        public async Task<IActionResult> consultaUsuarioPorID(int id)
        {
            if (id == null)
            {
                return BadRequest("ID de transacción inválido.");
            }
            var transaccion = await _usuarioServicio.consultaUsuarioPorID(id);
            if (transaccion == null)
            {
                return NotFound("No se encontró la transacción con el ID proporcionado.");
            }
            return Ok(transaccion);
        }



    }
}
