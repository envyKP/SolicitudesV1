using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solicitudes.API.Entidades.DTOs
{
    public class AuditoriaDTO
    {
        public int ID { get; set; }
        public string TABLA_AFECTADA { get; set; } = null!;
        public int ID_REGISTRO { get; set; }
        public string TIPO_OPERACION { get; set; } = null!;
        public DateTime FECHA_OPERACION { get; set; }
        public int? USUARIO_ID { get; set; }
        public string? DATOS_ANTERIORES { get; set; }
        public string? DATOS_NUEVOS { get; set; }
    }
}
