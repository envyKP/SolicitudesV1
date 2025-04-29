using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solicitudes.API.Entidades.Entities
{
    public partial class TBL_ROL
    {
        public int ROL_ID { get; set; }

        public string DESCRIPCION { get; set; } = null!;

        public DateTime FECHA_CREACION { get; set; }

        // Relación con tbl_usuarios
        public virtual ICollection<TBL_USUARIO> TBL_USUARIOS { get; set; } = new List<TBL_USUARIO>();
    }

}
