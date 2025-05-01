using System;
using System.Collections.Generic;

namespace Transacciones.API.Entidades.Entities;

public partial class TBL_TRANSACCIONE
{
    public string ID_TRX { get; set; } = null!;

    public int ID_PRODUCTO { get; set; }

    public DateOnly? FECHA { get; set; }

    public string TIPO_TRX { get; set; } = null!;

    public int CANTIDAD { get; set; }

    public decimal PRECIO_UNITARIO { get; set; }

    public decimal PRECIO_TOTAL { get; set; }

    public string? DETALLE_TRX { get; set; }

    public virtual TBL_PRODUCTO ID_PRODUCTONavigation { get; set; } = null!;
}
