using Solicitudes.API.Entidades.DTOs;
using Solicitudes.API.Entidades.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solicitudes.API.Aplicacion.Interfaces.IServicios
{
    public interface IUsuarioServicio
    {
        public Task<UsuarioDTO> consultaUsuarioPorID(int id);
    }
}
