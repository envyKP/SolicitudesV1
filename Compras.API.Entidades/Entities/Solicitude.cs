using System;
using System.Collections.Generic;

namespace Compras.API.Entidades.Entities;

public partial class Solicitude
{
    public int id { get; set; }

    public string? descripcion { get; set; }

    public decimal? monto { get; set; }

    public DateOnly? fecha_esperada { get; set; }

    public string estado { get; set; } = null!;

    public string? comentario { get; set; }
}
