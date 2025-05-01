using Microsoft.AspNetCore.Mvc;
using Transacciones.API.Aplicacion.Interfaces.Iservicio;
using Transacciones.API.Entidades.DTOs;

namespace Transacciones.API.Controllers
{
    
        [ApiController]
        [Route("api/[controller]")]
        public class TransaccionesController : Controller
        {
            private readonly ITransaccionesServicio _transaccionesServicio;

            public TransaccionesController(ITransaccionesServicio transaccionesServicio)
            {
                _transaccionesServicio = transaccionesServicio;
            }



            [HttpPost("crear")]
            public async Task<IActionResult> CrearTransaccion([FromBody] TransaccionesDTO transaccionDto)
            {
                if (!ModelState.IsValid)
                    return BadRequest("Datos inválidos.");

                var resultado = await _transaccionesServicio.CrearTransaccionAsync(transaccionDto);

                if (resultado.Contains("registrada exitosamente", StringComparison.OrdinalIgnoreCase))
                    return Ok(new { mensaje = resultado });

                return BadRequest(new { error = resultado });
            }


            [HttpPut("actualizar")]
            public async Task<IActionResult> ActualizarTransaccion([FromBody] TransaccionesDTO transaccionDto)
            {
                if (transaccionDto == null || string.IsNullOrWhiteSpace(transaccionDto.ID))
                {
                    return BadRequest("Datos de transacción inválidos.");
                }

                var resultado = await _transaccionesServicio.ActualizarTransaccionAsync(transaccionDto);

                if (resultado.Contains("Error"))
                {
                    return BadRequest(resultado);
                }

                return Ok(resultado);
            }



            [HttpGet("detalle/{idTrx}")]
            public async Task<IActionResult> GetTransaccion(string idTrx)
            {
                if (string.IsNullOrWhiteSpace(idTrx))
                {
                    return BadRequest("ID de transacción inválido.");
                }

                var transaccion = await _transaccionesServicio.GetTransaccion(idTrx);

                if (transaccion == null)
                {
                    return NotFound("No se encontró la transacción con el ID proporcionado.");
                }

                return Ok(transaccion);
            }


            [HttpDelete("eliminar/{idTrx}")]
            public async Task<IActionResult> EliminarTransaccion(string idTrx)
            {
                // Validar si el ID de la transacción es nulo o vacío
                if (string.IsNullOrWhiteSpace(idTrx))
                {
                    return BadRequest("ID de transacción inválido.");
                }

                // Llamar al servicio para eliminar la transacción
                var resultado = await _transaccionesServicio.EliminarTransaccionAsync(idTrx);

                // Si hay algún error, devolver una respuesta de error
                if (resultado.Contains("Error"))
                {
                    return BadRequest(new { error = resultado });
                }

                // Si la transacción se eliminó exitosamente, devolver una respuesta de éxito
                return Ok(new { mensaje = resultado });
            }


            [HttpGet("listar")]
            public async Task<IActionResult> ListaTrxAsync()
            {
                try
                {
                    // call servicio para obtener la lista de transacciones
                    var transacciones = await _transaccionesServicio.ListaTrxAsync();

                    // si no hay transacciones, devolvemos una respuesta con lista vacía
                    if (transacciones == null || !transacciones.Any())
                    {
                        return Ok(new List<TransaccionesDTO>());
                    }

                    // retornamos la lista de transacciones
                    return Ok(transacciones);
                }
                catch (Exception ex)
                {
                    // En caso de error, retornamos un error con el mensaje adecuado
                    return StatusCode(500, $"Error al recuperar la lista de transacciones: {ex.Message}");
                }
            }



    }
}
