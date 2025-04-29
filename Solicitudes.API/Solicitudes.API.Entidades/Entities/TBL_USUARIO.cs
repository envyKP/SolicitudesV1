using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Solicitudes.API.Entidades.Entities;

namespace Solicitudes.API.Entidades.Entities
{

    public partial class TBL_USUARIO
    {
        public int ID { get; set; }

        public string NOMBRES { get; set; } = null!;

        public string USERNAME { get; set; } = null!;

        public int ROL_ID { get; set; }

        public string TELEFONO { get; set; } = null!;

        public string CORREO { get; set; } = null!;

        // Relación con tbl_roles
        public virtual TBL_ROL TBL_ROL { get; set; } = null!;

        // Relación con tbl_auditoria
        public virtual ICollection<TBL_AUDITORIA> TBL_AUDITORIAS { get; set; } = new List<TBL_AUDITORIA>();
    }

}
