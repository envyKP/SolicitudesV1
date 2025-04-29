using System;
using System.Collections.Generic;

namespace Compras.API.Entidades.Entities;

public partial class Role
{
    public int rol_id { get; set; }

    public string descripcion { get; set; } = null!;

    public DateTime? fecha_creacion { get; set; }

    public virtual ICollection<Usuario> usuarios { get; set; } = new List<Usuario>();
}
