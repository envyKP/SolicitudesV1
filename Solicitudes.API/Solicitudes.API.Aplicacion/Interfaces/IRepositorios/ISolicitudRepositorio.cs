using Solicitudes.API.Entidades.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solicitudes.API.Aplicacion.Interfaces.IRepositorios
{

    public interface ISolicitudRepositorio
    {
        Task<string> GuardarSolicitudAsync(TBL_SOLICITUD solicitud);
    }

}
