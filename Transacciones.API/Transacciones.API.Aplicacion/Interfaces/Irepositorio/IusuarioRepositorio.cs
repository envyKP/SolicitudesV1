using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Transacciones.API.Entidades.Entities;

namespace Transacciones.API.Aplicacion.Interfaces.Irepositorio
{
    public interface IusuarioRepositorio
    {
        public Task <TBL_USUARIO> GetUsuarioRepositorio (int id);

    }
}
