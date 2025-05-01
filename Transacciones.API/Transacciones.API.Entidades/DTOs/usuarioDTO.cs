using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transacciones.API.Entidades.DTOs
{
    public class usuarioDTO
    {
        public int Idusuario { get; set; }

        public string Nombre { get; set; }

        [MaxLength(1)]
        public string Estado { get; set; }

        [Required]
        [Column("ROL")]
        [MaxLength(10)]
        public string Rol { get; set; }

    }
}
