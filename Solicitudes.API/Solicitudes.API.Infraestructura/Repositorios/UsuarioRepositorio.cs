using Microsoft.EntityFrameworkCore;
using Solicitudes.API.Aplicacion.Interfaces.Interfaces;
using Solicitudes.API.Entidades.Entities;
using Solicitudes.API.Infraestructura.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solicitudes.API.Infraestructura.Repositorios
{
    public class UsuarioRepositorio : IUsuariosRepositorio
    {
        private readonly SolicitudesContextBD _contextSolicitudes;

        public UsuarioRepositorio(SolicitudesContextBD context)
        {
            _contextSolicitudes = context;
        }


        public async Task<TBL_USUARIO> consultaUsuarioPorID(int id)
        {
            // Buscamos la transacci�n por su ID
            return await _contextSolicitudes.TBL_USUARIO.FirstOrDefaultAsync(t => t.ID == id);
        }

    }
}
