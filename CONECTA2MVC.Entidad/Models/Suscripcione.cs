using System;
using System.Collections.Generic;

namespace CONECTA2MVC.Entidad.Models;

public partial class Suscripcione
{
    public int Id { get; set; }

    public DateTime? Fechainicio { get; set; }

    public DateTime? Fechafin { get; set; }

    public bool? Estado { get; set; }

    public int? Idusuario { get; set; }

    public int? Idplan { get; set; }

    public virtual Plane? IdplanNavigation { get; set; }

    public virtual Usuario? IdusuarioNavigation { get; set; }
}
