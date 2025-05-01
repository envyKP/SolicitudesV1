using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transacciones.API.Entidades.DTOs;
using Transacciones.API.Entidades.Entities;

namespace Transacciones.API.Aplicacion.Interfaces.Iservicio
{
    public interface ITransaccionesServicio
    {

        public Task<TransaccionesDTO> GetTransaccion(string idTrx);
        public Task<string> CrearTransaccionAsync(TransaccionesDTO transaccionDTO);
        public Task<string> ActualizarTransaccionAsync(TransaccionesDTO transaccionDto);
        public Task<string> EliminarTransaccionAsync(string idTrx);

        public Task<IEnumerable<TransaccionesDTO>> ListaTrxAsync();

    }
}
