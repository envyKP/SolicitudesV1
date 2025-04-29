using Compras.API.Entidades.DTOs;
using Compras.API.Entidades.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compras.API.Aplicacion.Interfaces.IServicios
{
    public interface IUsuarioServicio
    {
        public Task<UsuarioDto> GetTransaccion(int id);
    }
}
