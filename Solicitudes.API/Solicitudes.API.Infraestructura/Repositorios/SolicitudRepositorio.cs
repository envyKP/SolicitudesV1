using Solicitudes.API.Aplicacion.Interfaces.IRepositorios;
using Solicitudes.API.Entidades.Entities;
using Solicitudes.API.Infraestructura.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solicitudes.API.Infraestructura.Repositorios
{
    public class SolicitudRepositorio : ISolicitudRepositorio
    {


        private readonly SolicitudesContextBD _context;

        public SolicitudRepositorio(SolicitudesContextBD context)
        {
            _context = context;
        }

        public async Task<string> GuardarSolicitudAsync(TBL_SOLICITUD solicitud)
        {
            try
            {
                await _context.TBL_SOLICITUD.AddAsync(solicitud);
                await _context.SaveChangesAsync();
                return "Solicitud creada exitosamente."; ;
            }
            catch (Exception ex)
            {
                string mensajeError = ex.InnerException?.Message ?? ex.Message;
                return mensajeError.Length > 400 ? mensajeError.Substring(0, 400) : mensajeError;
            }
        }

    }
}
