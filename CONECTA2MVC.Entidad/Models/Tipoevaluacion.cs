using System;
using System.Collections.Generic;

namespace CONECTA2MVC.Entidad.Models;

public partial class Tipoevaluacion
{
    public int Id { get; set; }

    public string Tipo { get; set; } = null!;

    public string Descripción { get; set; } = null!;

    public bool? Estado { get; set; }

    public virtual ICollection<Evaluacion> Evaluacions { get; set; } = new List<Evaluacion>();
}
