using System;
using System.Collections.Generic;

namespace Transacciones.API.Entidades.Entities;

public partial class TBL_PRODUCTO
{

    public TBL_PRODUCTO()
    {
        TBL_TRANSACCIONEs = new HashSet<TBL_TRANSACCIONE>();
    }

    //no necesita más campos para la relacion
    public int ID_PRODUCTO { get; set; }


    // Se puede tener otras propiedades como NOMBRE_PRODUCTO, etc.
    // para otras relaciones con otras entidades de DB
    public virtual ICollection<TBL_TRANSACCIONE> TBL_TRANSACCIONEs { get; set; }

}
