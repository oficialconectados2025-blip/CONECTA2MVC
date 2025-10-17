using System;
using System.Collections.Generic;

namespace CONECTA2MVC.Entidad.Models;

public partial class Notificacione
{
    public int Id { get; set; }

    public string Tipo { get; set; } = null!;

    public string Mensaje { get; set; } = null!;

    public DateTime Fechaenviado { get; set; }

    public bool? Leido { get; set; }

    public int? Idusuario { get; set; }

    public virtual Usuario? IdusuarioNavigation { get; set; }
}
