using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transacciones.API.Aplicacion.Interfaces.Irepositorio;
using Transacciones.API.Entidades.Entities;
using Transacciones.API.Infraestructura.Context;

namespace Transacciones.API.Infraestructura.Repositorios
{
    public class UsuarioRepositorio : IusuarioRepositorio
    {
        
        
        private readonly LogicStudioTransaccionesContext _contextTransacciones;


        public UsuarioRepositorio (LogicStudioTransaccionesContext contextTransacciones)
        {
            _contextTransacciones = contextTransacciones;
        }


        public async Task<TBL_USUARIO> GetUsuarioRepositorio(int id)
        {
            return await _contextTransacciones.TBL_USUARIOS.FirstOrDefaultAsync(e => e.id_usuario == id);
        }


    }
}
