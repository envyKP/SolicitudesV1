using System;
using System.Collections.Generic;

namespace Compras.API.Entidades.Entities;

public partial class Auditorium
{
    public int id { get; set; }

    public string tabla_afectada { get; set; } = null!;

    public int id_registro { get; set; }

    public string tipo_operacion { get; set; } = null!;

    public DateTime? fecha_operacion { get; set; }

    public int? usuario_id { get; set; }

    public string? datos_anteriores { get; set; }

    public string? datos_nuevos { get; set; }

    public virtual Usuario? Usuario { get; set; }
}
