using Solicitudes.API.Entidades.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solicitudes.API.Aplicacion.Interfaces.IServicios
{
    public interface ISolicitudService
    {
        Task<string> CrearSolicitudAsync(SolicitudDTO solicitudDTO);
    }
}
