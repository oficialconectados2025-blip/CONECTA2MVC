using System;
using System.Collections.Generic;

namespace CONECTA2MVC.Entidad.Models;

public partial class Likecomtutoriale
{
    public int Id { get; set; }

    public DateTime? Fecha { get; set; }

    public int? Idusuario { get; set; }

    public int? Idcomentariotuto { get; set; }

    public virtual Comentariotutoriale? IdcomentariotutoNavigation { get; set; }

    public virtual Usuario? IdusuarioNavigation { get; set; }
}
