using Solicitudes.API.Entidades.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solicitudes.API.Aplicacion.Interfaces.Interfaces
{
    public interface IUsuariosRepositorio
    {
        public Task<TBL_USUARIO> consultaUsuarioPorID(int id);
    }
}
