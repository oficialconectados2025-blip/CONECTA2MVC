using System;
using System.Collections.Generic;

namespace CONECTA2MVC.Entidad.Models;

public partial class Tipopreguntum
{
    public int Id { get; set; }

    public string Tipo { get; set; } = null!;

    public string Descripción { get; set; } = null!;

    public bool? Estado { get; set; }

    public virtual ICollection<Pregunta> Pregunta { get; set; } = new List<Pregunta>();
}
