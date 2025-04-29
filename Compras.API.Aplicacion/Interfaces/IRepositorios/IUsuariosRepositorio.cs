using Compras.API.Entidades.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compras.API.Aplicacion.Interfaces.Interfaces
{
    public interface IUsuariosRepositorio
    {
        public Task<Usuario> GetTransaccion(int id);
    }
}
