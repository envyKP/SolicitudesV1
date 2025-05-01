using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transacciones.API.Aplicacion.Interfaces.Irepositorio;
using Transacciones.API.Aplicacion.Interfaces.Iservicio;
using Transacciones.API.Entidades.DTOs;
using Transacciones.API.Entidades.Entities;


namespace Transacciones.API.Aplicacion.Servicios
{
    
    //TransaccionesServicio implementa la interfaz ITransaccionesServicio
    public class TransaccionesServicio : ITransaccionesServicio
    {
        
        
        private readonly ITransaccionesRepositorio _transaccionesRepositorio;
        private readonly IProductoProxyService _productoProxyService;
        private readonly IMapper _mapper;

        public TransaccionesServicio(ITransaccionesRepositorio transaccionesRepositorio, 
                                     IProductoProxyService     productoProxyService,
                                     IMapper mapper)
        {
            _transaccionesRepositorio = transaccionesRepositorio;
            _productoProxyService = productoProxyService;
            _mapper = mapper;
        }


        public async Task<TransaccionesDTO> GetTransaccion(string idTrx)
        {
            try
            {
                // consulto la transaccion de la capa de repositorio
                var trxExistente = await _transaccionesRepositorio.GetTransaccion(idTrx);

                // Si no se encuentra retornar null
                if (trxExistente == null)
                {
                    return null;  
                }

                // Mapear la entidad a DTO
                var transaccionDto = _mapper.Map<TransaccionesDTO>(trxExistente);

                // Xq null 
                return transaccionDto;
            }
            catch (Exception ex)
            {
                // Manejo de error y retornando null si ocurre un fallo
                return null;
            }
        }


        public async Task<IEnumerable<TransaccionesDTO>> ListaTrxAsync()
        {
            try
            {
                // Llamamos al repositorio para obtener la lista de transacciones
                var transacciones = await _transaccionesRepositorio.ListaTrxAsync();

                // Si no hay transacciones, devolvemos una lista vacía
                if (transacciones == null || !transacciones.Any())
                {
                    return new List<TransaccionesDTO>();
                }

                // convertimos las transacciones a DTOs
                var transaccionesDto = transacciones.Select(t => new TransaccionesDTO
                {
                    ID             = t.ID_TRX,
                    IdProducto     = t.ID_PRODUCTO,
                    fecha          = t.FECHA,
                    TipoTrx        = t.TIPO_TRX,
                    cantidad       = t.CANTIDAD,
                    PrecioUnitario = t.PRECIO_UNITARIO,
                    DetalleTrx     = t.DETALLE_TRX
                });

                return transaccionesDto;
            }
            catch (Exception ex)
            {
                // En caso de error, lanzamos una excepción con el mensaje adecuado
                throw new Exception("Error al recuperar la lista de transacciones.", ex);
            }
        }


        public async Task<string> CrearTransaccionAsync(TransaccionesDTO transaccionDto)
        {
            try
            {
                
                // Obtener el producto a través del microservicio de productos
                var stockDisponible = await _productoProxyService.ObtenerProductoPorIdAsync(transaccionDto.IdProducto);

                if (stockDisponible == null)
                {
                    return "Error: El producto no existe.";
                }


                // Verificar stock si es una venta
                if (transaccionDto.TipoTrx.ToLower() == "venta")
                {
                    if (stockDisponible.Stock < transaccionDto.cantidad)
                    {
                        return "Error: Stock insuficiente para realizar la venta.";
                    }
                }

                // Mapear DTO a entidad
                var transaccion = _mapper.Map<TBL_TRANSACCIONE>(transaccionDto);


                // Calcular el precio total antes de enviar al repositorio
                transaccion.PRECIO_TOTAL = transaccion.CANTIDAD * transaccion.PRECIO_UNITARIO;
                transaccion.ID_TRX = transaccion.ID_TRX.ToUpper();


                // Ejecutar y reenviar la respuesta de la capa de infraestructura sea exito o error
                var resultado = await _transaccionesRepositorio.CrearTransaccionAsync(transaccion);

                //Actualizar stock a través del microservicio de productos
                await _productoProxyService.ActualizarStockProductoAsync(new ActualizarStockDTO
                {
                    Id             = transaccionDto.IdProducto,
                    Cantidad       = transaccionDto.cantidad,
                    TipoTrx        = transaccionDto.TipoTrx
                });


                return resultado;
            }
            catch (Exception ex)
            {
                // Captura de errores inesperados (por fuera del repo)
                return $"Ocurrió un error inesperado: {ex.Message.Substring(0, Math.Min(300, ex.Message.Length))}";
            }
        }


        public async Task<string> ActualizarTransaccionAsync(TransaccionesDTO transaccionDto)
        {
            try
            {
                //Obtener el producto a traves del microservicio de productos
                var stockDisponible = await _productoProxyService.ObtenerProductoPorIdAsync(transaccionDto.IdProducto);

                if (stockDisponible == null)
                {
                    return "Error: El producto no existe.";
                }


                // Verificar stock si es una venta
                if (transaccionDto.TipoTrx.ToLower() == "venta")
                {
                    if (stockDisponible.Stock < transaccionDto.cantidad)
                    {
                        return "Error: Stock insuficiente para realizar la venta.";
                    }
                }

                // Mapear DTO a entidad
                var transaccion = _mapper.Map<TBL_TRANSACCIONE>(transaccionDto);
                
                transaccion.PRECIO_TOTAL = transaccion.CANTIDAD * transaccion.PRECIO_UNITARIO;
                transaccion.ID_TRX = transaccion.ID_TRX.ToUpper();

                
                // Enviar la entidad a la capa de infraestructura para la actualizacion
                var resultado = await _transaccionesRepositorio.ActualizarTrxAsync(transaccion);


                if (!resultado.ToLower().Contains("exitosamente"))
                {
                    return $"Error al actualizar la transacción: {resultado}";
                }

                //Actualizar stock a través del microservicio de productos
                await _productoProxyService.ActualizarStockProductoAsync(new ActualizarStockDTO
                {
                    Id       = transaccionDto.IdProducto,
                    Cantidad = transaccionDto.cantidad,
                    TipoTrx  = transaccionDto.TipoTrx
                });

                return resultado;

            }
            catch (Exception ex)
            {
                // Captura de errores inesperados
                return $"Ocurrió un error inesperado: {ex.Message.Substring(0, Math.Min(300, ex.Message.Length))}";
            }
        }

        public async Task<string> EliminarTransaccionAsync(string idTrx)
        {
            try
            {
                // consulta si la transaccion existe
                var transaccionExiste = await _transaccionesRepositorio.GetTransaccion(idTrx);

                if (transaccionExiste == null)
                {
                    return "Error: La transaccion con el ID especificado no existe.";
                }

                //call al repo para eliminar la transacción
                var resultado = await _transaccionesRepositorio.EliminarTransaccionAsync(idTrx);
                return resultado;
            }
            catch (Exception ex)
            {
                // Manejo de excepciones y retorno del mensaje de error
                return $"Ocurrió un error inesperado: {ex.Message.Substring(0, Math.Min(300, ex.Message.Length))}";
            }
        }


    }


}
