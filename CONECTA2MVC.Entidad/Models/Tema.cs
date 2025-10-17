using System;
using System.Collections.Generic;

namespace CONECTA2MVC.Entidad.Models;

public partial class Tema
{
    public int Id { get; set; }

    public string Titulo { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public int? Orden { get; set; }

    public int? Idunidad { get; set; }

    public virtual Unidad? IdunidadNavigation { get; set; }

    public virtual ICollection<Progresotema> Progresotemas { get; set; } = new List<Progresotema>();
}
