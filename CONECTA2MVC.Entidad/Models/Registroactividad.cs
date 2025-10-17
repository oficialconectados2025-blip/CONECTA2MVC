using System;
using System.Collections.Generic;

namespace CONECTA2MVC.Entidad.Models;

public partial class Registroactividad
{
    public int Id { get; set; }

    public string Accion { get; set; } = null!;

    public DateTime? Fecha { get; set; }

    public string Detalle { get; set; } = null!;

    public int? Idusuario { get; set; }

    public virtual Usuario? IdusuarioNavigation { get; set; }
}
