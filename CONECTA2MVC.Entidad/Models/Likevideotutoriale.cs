using System;
using System.Collections.Generic;

namespace CONECTA2MVC.Entidad.Models;

public partial class Likevideotutoriale
{
    public int Id { get; set; }

    public DateTime? Fecha { get; set; }

    public int? Idusuario { get; set; }

    public int? Idvidtutorial { get; set; }

    public virtual Usuario? IdusuarioNavigation { get; set; }

    public virtual Videotutoriale? IdvidtutorialNavigation { get; set; }
}
