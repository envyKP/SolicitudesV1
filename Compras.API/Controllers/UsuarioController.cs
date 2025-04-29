using Compras.API.Aplicacion.Interfaces.IServicios;
using Microsoft.AspNetCore.Mvc;

namespace Compras.API.Controllers
{
    public class UsuarioController : Controller
    {

        private readonly IUsuarioServicio _usuarioServicio;

        public UsuarioController(IUsuarioServicio usuarioServicio) { 
        _usuarioServicio = usuarioServicio;
        }


        [HttpGet("detalle/{id}")]
        public async Task<IActionResult> GetTransaccion(int id)
        {
            if ( id == null)
            {
                return BadRequest("ID de transacción inválido.");
            }
            var transaccion = await _usuarioServicio.GetTransaccion(id);
            if (transaccion == null)
            {
                return NotFound("No se encontró la transacción con el ID proporcionado.");
            }
            return Ok(transaccion);
        }




    }
}
