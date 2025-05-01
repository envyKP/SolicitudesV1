using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transacciones.API.Entidades.DTOs
{
    public class ActualizarStockDTO
    {
        public int Id { get; set; }
        public int Cantidad { get; set; }
        public string TipoTrx { get; set; } = string.Empty; // "compra" o "venta"
       
    }


}
