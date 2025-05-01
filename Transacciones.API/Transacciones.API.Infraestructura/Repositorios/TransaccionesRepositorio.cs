using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transacciones.API.Aplicacion.Interfaces.Irepositorio;
using Transacciones.API.Entidades.DTOs;
using Transacciones.API.Entidades.Entities;
using Transacciones.API.Infraestructura.Context;
using System.Drawing;

namespace Transacciones.API.Infraestructura.Repositorios
{
    public class TransaccionesRepositorio : ITransaccionesRepositorio
    {

        private readonly LogicStudioTransaccionesContext _contextTransacciones;

        public TransaccionesRepositorio(LogicStudioTransaccionesContext context)
        {
            _contextTransacciones = context;
        }



        public async Task<TBL_TRANSACCIONE> GetTransaccion(string idTrx)
        {
            // Buscamos la transacción por su ID_TRX
             return await _contextTransacciones.TBL_TRANSACCIONE.FirstOrDefaultAsync(t => t.ID_TRX == idTrx);
          
        }




        public async Task<bool> GetProducto(int id)
        {
            
            //var producto = await _context.TBL_PRODUCTO.FindAsync(id);

            var producto = await _contextTransacciones.TBL_PRODUCTO.FirstOrDefaultAsync(p => p.ID_PRODUCTO == Convert.ToInt32(id));

            return producto != null;

        }

                

        public async Task<string> CrearTransaccionAsync(TBL_TRANSACCIONE transaccion)
        {
            try
            {
                await _contextTransacciones.TBL_TRANSACCIONE.AddAsync(transaccion);
                await _contextTransacciones.SaveChangesAsync();

                return "Transacción registrada exitosamente.";
            }
            catch (DbUpdateException dbEx)
            {
                return $"Error al guardar la transacción: {dbEx.Message.Substring(0, Math.Min(300, dbEx.Message.Length))}";

            }
            catch (SqlException sqlEx)
            {
                return $"Error de base de datos: {sqlEx.Message.Substring(0, 300)}";
            }
            catch (Exception ex)
            {
                return $"Ocurrió un error inesperado: {ex.Message.Substring(0, 300)}";
            }
        }


        public async Task<string> ActualizarTrxAsync(TBL_TRANSACCIONE trx)
        {
            try
            {
                // verificamos si existe la transaccion antes de actualizar
                var trxExistente = await _contextTransacciones.TBL_TRANSACCIONE.FindAsync(trx.ID_TRX);

                if (trxExistente == null)
                    return "No se encontró la transacción a actualizar.";

                // solo actualizamos los campos necesarios (respetando el tracking)
                _contextTransacciones.Entry(trxExistente).CurrentValues.SetValues(trx);

                await _contextTransacciones.SaveChangesAsync();

                return "Transacción actualizada exitosamente.";
            }
            catch (DbUpdateException dbEx)
            {
                return $"Error al actualizar transaccion: {dbEx.InnerException?.Message?.Substring(0, Math.Min(300, dbEx.InnerException.Message.Length))}";
            }
            catch (Exception ex)
            {
                return $"Error inesperado: {ex.Message.Substring(0, Math.Min(300, ex.Message.Length))}";
            }
        }

        public async Task<string> EliminarTransaccionAsync(string idTrx)
        {
            try
            {
                var transaccion = await _contextTransacciones.TBL_TRANSACCIONE.FirstOrDefaultAsync(t => t.ID_TRX == idTrx);

                if (transaccion == null)
                {
                    return "Error: No se encontró la transacción con el ID especificado.";
                }

                _contextTransacciones.TBL_TRANSACCIONE.Remove(transaccion);
                await _contextTransacciones.SaveChangesAsync();

                return "Transacción eliminada exitosamente.";
            }
            catch (Exception ex)
            {
                return $"Ocurrió un error al eliminar la transacción: {ex.Message}";
            }
        }

        public async Task<IEnumerable<TBL_TRANSACCIONE>> ListaTrxAsync()
        {
            try
            {
                // recuperp todas las transacciones desde la base de datos
                var transacciones = await _contextTransacciones.TBL_TRANSACCIONE.ToListAsync();

                // Validación si no hay transacciones
                if (transacciones == null || !transacciones.Any())
                {
                    // devolver una lista vacía o lanzar una excepcion dependiendo del caso
                    return new List<TBL_TRANSACCIONE>();
                }

                return transacciones;
            }
            catch (Exception ex)
            {
                // excepcion manejada para asegurar un buen diagnopstico de problemas
                throw new Exception("Error al recuperar la lista de transacciones desde la base de datos.", ex);
            }
        }



    }
}
