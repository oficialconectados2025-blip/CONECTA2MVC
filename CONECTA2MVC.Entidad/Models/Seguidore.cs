using System;
using System.Collections.Generic;

namespace CONECTA2MVC.Entidad.Models;

public partial class Seguidore
{
    public int Id { get; set; }

    public int? Idusuario { get; set; }

    public int? Seguidorusuarioid { get; set; }

    public DateTime? Fecha { get; set; }

    public virtual Usuario? IdusuarioNavigation { get; set; }

    public virtual Usuario? Seguidorusuario { get; set; }
}
