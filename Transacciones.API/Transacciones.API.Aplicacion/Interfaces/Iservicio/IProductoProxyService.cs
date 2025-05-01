using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transacciones.API.Entidades.DTOs;

namespace Transacciones.API.Aplicacion.Interfaces.Iservicio
{
    public interface IProductoProxyService
    {
        Task<ProductoDTO?> ObtenerProductoPorIdAsync(int idProducto);
        Task<bool> ActualizarStockProductoAsync(ActualizarStockDTO dto);
    }

}
