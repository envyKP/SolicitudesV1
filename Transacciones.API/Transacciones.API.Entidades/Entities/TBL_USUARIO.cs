using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transacciones.API.Entidades.Entities
{
    public partial class TBL_USUARIO
    {
        public int id_usuario { get; set; }

        public string Nombre { get; set; }

        [MaxLength(1)]
        public string Estado { get; set; }

        [Required]
        [Column("ROL")]
        [MaxLength(10)]
        public string Rol { get; set; }

    }
}
