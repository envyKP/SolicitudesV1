using Compras.API.Entidades.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compras.API.Entidades.DTOs
{
    public class UsuarioDto
    {
        public int id { get; set; }

        public string nombres { get; set; } = null!;

        public string username { get; set; } = null!;

        public int rol_id { get; set; }

        public string? telefono { get; set; }

        public string? correo { get; set; }

        public virtual ICollection<Auditorium> auditoria { get; set; } = new List<Auditorium>();

        public virtual Role rol { get; set; } = null!;
    }
}
