using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transacciones.API.Entidades.DTOs;
using Transacciones.API.Entidades.Entities;

namespace Transacciones.API.Aplicacion.Interfaces.Irepositorio
{
    public interface ITransaccionesRepositorio
    {

        public Task<TBL_TRANSACCIONE> GetTransaccion(string idTrx);

        public Task<bool> GetProducto(int id);

        public Task<string> CrearTransaccionAsync(TBL_TRANSACCIONE transaccion);

        public Task<string> ActualizarTrxAsync(TBL_TRANSACCIONE transaccion);

        public Task<string> EliminarTransaccionAsync(string idTrx);

        public Task<IEnumerable<TBL_TRANSACCIONE>> ListaTrxAsync();


    }
}
