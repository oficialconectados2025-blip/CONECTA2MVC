using System;
using System.Collections.Generic;

namespace CONECTA2MVC.Entidad.Models;

public partial class Unidad
{
    public int Id { get; set; }

    public string Titulo { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public int? Orden { get; set; }

    public int? Idmodulo { get; set; }

    public virtual ICollection<Actividad> Actividads { get; set; } = new List<Actividad>();

    public virtual ICollection<Foro> Foros { get; set; } = new List<Foro>();

    public virtual Modulo? IdmoduloNavigation { get; set; }

    public virtual ICollection<Progresounidad> Progresounidads { get; set; } = new List<Progresounidad>();

    public virtual ICollection<Recursounidad> Recursounidads { get; set; } = new List<Recursounidad>();

    public virtual ICollection<Tema> Temas { get; set; } = new List<Tema>();
}
