using System;
using System.Collections.Generic;

namespace CONECTA2MVC.Entidad.Models;

public partial class Pago
{
    public int Id { get; set; }

    public decimal? Monto { get; set; }

    public string? Metodopago { get; set; }

    public DateTime? Fechapago { get; set; }

    public string? Idtransaccion { get; set; }

    public int? Idplan { get; set; }

    public int? Idusuario { get; set; }

    public virtual Plane? IdplanNavigation { get; set; }

    public virtual Usuario? IdusuarioNavigation { get; set; }
}
