using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transacciones.API.Entidades.DTOs
{
    public class ProductoDTO
    {
        public int Id { get; set; }     //ID_PRODUCTO
        public string NombreProducto { get; set; } = "";   // NOMBRE_PRODUCTO
        public int Stock { get; set; } // STOCK
        public string? DescripcionProducto { get; set; }   // DESCRIPCION_PRODUCTO (nullable)
        public string CategoriaProducto { get; set; } = ""; // CATEGORIA_PRODUCTO
        public byte[]? Imagen { get; set; }                // IMAGEN (binario, puede ser null)
        public decimal Precio { get; set; }                // PRECIO

    }
}
