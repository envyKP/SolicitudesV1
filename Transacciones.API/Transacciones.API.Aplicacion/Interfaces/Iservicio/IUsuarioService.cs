using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transacciones.API.Entidades.DTOs;
using Transacciones.API.Entidades.Entities;

namespace Transacciones.API.Aplicacion.Interfaces.Iservicio
{
    public interface IUsuarioService
    {
        public Task<usuarioDTO> GetUsuarioRepositorio(int id);
    }

}
