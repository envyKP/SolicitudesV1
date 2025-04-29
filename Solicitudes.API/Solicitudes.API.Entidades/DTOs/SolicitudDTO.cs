using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solicitudes.API.Entidades.DTOs
{
    public class SolicitudDTO
    {
        public int ID { get; set; }
        public string DESCRIPCION { get; set; } = null!;
        public decimal MONTO { get; set; }
        public DateTime? FECHA_ESPERADA { get; set; }
        public string ESTADO { get; set; } = null!;
        public string? COMENTARIO { get; set; }
    }
}
