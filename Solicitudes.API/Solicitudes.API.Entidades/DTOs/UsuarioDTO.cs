using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solicitudes.API.Entidades.DTOs
{
    public class UsuarioDTO
    {
        public int ID { get; set; }
        public string NOMBRES { get; set; } = null!;
        public string USERNAME { get; set; } = null!;
        public int ROL_ID { get; set; }
        public string CLAVE { get; set; } = null!;
        public string CORREO { get; set; } = null!;

    }
}
