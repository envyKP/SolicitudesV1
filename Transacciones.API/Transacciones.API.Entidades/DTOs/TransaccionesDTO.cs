using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transacciones.API.Entidades.DTOs
{
    public class TransaccionesDTO
    {

        public string     ID { get; set; } = null!;
        public int        IdProducto { get; set; }
        public DateOnly?  fecha { get; set; }
        public string     TipoTrx { get; set; } = null!;
        public int        cantidad { get; set; }
        public decimal    PrecioUnitario { get; set; }
        //public decimal    PrecioTotal { get; set; }
        public string?    DetalleTrx { get; set; }

      
    }
}
