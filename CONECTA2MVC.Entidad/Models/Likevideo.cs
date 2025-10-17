using System;
using System.Collections.Generic;

namespace CONECTA2MVC.Entidad.Models;

public partial class Likevideo
{
    public int Id { get; set; }

    public int? Idusuario { get; set; }

    public int? Idvideocurso { get; set; }

    public virtual Usuario? IdusuarioNavigation { get; set; }

    public virtual Videocurso? IdvideocursoNavigation { get; set; }
}
