using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solicitudes.API.Entidades.DTOs
{
    public class RolDTO
    {
        public int ROL_ID { get; set; }
        public string DESCRIPCION { get; set; } = null!;
        public DateTime FECHA_CREACION { get; set; }

    }
}
