using Microsoft.AspNetCore.Mvc;
using Solicitudes.API.Aplicacion.Interfaces.IServicios;
using Solicitudes.API.Entidades.DTOs;

namespace Solicitudes.API.Controllers
{
    public class SolicitudController : Controller
    {
        private readonly ISolicitudService _solicitudService;

        // Constructor
        public SolicitudController(ISolicitudService solicitudService)
        {
            _solicitudService = solicitudService;
        }


        // POST api/solicitud
        [HttpPost("crearSolicitud")]
        public async Task<IActionResult> CrearSolicitud([FromBody] SolicitudDTO solicitudDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest("Datos de solicitud inválidos.");

            var resultado = await _solicitudService.CrearSolicitudAsync(solicitudDTO);

            if (resultado.ToLower().Contains("error") || resultado.ToLower().Contains("excepción") || resultado.ToLower().Contains("problema"))
                return BadRequest(resultado);

            return Ok(resultado);
        }

    }
}
