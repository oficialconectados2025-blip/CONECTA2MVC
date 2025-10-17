using System;
using System.Collections.Generic;

namespace CONECTA2MVC.Entidad.Models;

public partial class Votosugerencium
{
    public int Id { get; set; }

    public int? Idusuario { get; set; }

    public int? Idsugerencia { get; set; }

    public DateTime? Fechavoto { get; set; }

    public virtual Sugerenciacurso? IdsugerenciaNavigation { get; set; }

    public virtual Usuario? IdusuarioNavigation { get; set; }
}
