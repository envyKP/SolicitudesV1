using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Transacciones.API.Aplicacion.Interfaces.Iservicio;
using Transacciones.API.Entidades.DTOs;

namespace Transacciones.API.Aplicacion.Servicios
{

    public class ProductoProxyService : IProductoProxyService
    {
        private readonly HttpClient _httpClient;

        public ProductoProxyService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        public async Task<ProductoDTO?> ObtenerProductoPorIdAsync(int idProducto)
        {
            var response = await _httpClient.GetAsync($"api/Producto/{idProducto}");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<ProductoDTO>();
            }
            return null;
        }
        
        public async Task<bool> ActualizarStockProductoAsync(ActualizarStockDTO StockDTO)
        {
            var producto = await ObtenerProductoPorIdAsync(StockDTO.Id);
            if (producto == null)
                return false;

            if (StockDTO.TipoTrx.ToLower() == "venta" && producto.Stock < StockDTO.Cantidad)
                return false;

            producto.Stock = StockDTO.TipoTrx.ToLower() == "compra"
                ? producto.Stock + StockDTO.Cantidad
                : producto.Stock - StockDTO.Cantidad;

            var response = await _httpClient.PutAsJsonAsync($"api/Producto/{StockDTO.Id}", producto);
            return response.IsSuccessStatusCode;
        }
    }

}
