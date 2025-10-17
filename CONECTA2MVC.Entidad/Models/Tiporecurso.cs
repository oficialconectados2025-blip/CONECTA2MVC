using System;
using System.Collections.Generic;

namespace CONECTA2MVC.Entidad.Models;

public partial class Tiporecurso
{
    public int Id { get; set; }

    public string Tipo { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public bool? Estado { get; set; }

    public virtual ICollection<Recursounidad> Recursounidads { get; set; } = new List<Recursounidad>();
}
