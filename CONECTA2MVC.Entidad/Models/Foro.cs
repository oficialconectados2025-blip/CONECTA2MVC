using System;
using System.Collections.Generic;

namespace CONECTA2MVC.Entidad.Models;

public partial class Foro
{
    public int Id { get; set; }

    public string Titulo { get; set; } = null!;

    public string Descripcino { get; set; } = null!;

    public DateTime Fechacreacion { get; set; }

    public DateTime Fechamodificacion { get; set; }

    public int? Idunidad { get; set; }

    public virtual ICollection<Hilosforo> Hilosforos { get; set; } = new List<Hilosforo>();

    public virtual Unidad? IdunidadNavigation { get; set; }
}
