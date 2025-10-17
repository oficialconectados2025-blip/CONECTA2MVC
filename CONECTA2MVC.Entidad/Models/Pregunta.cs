using System;
using System.Collections.Generic;

namespace CONECTA2MVC.Entidad.Models;

public partial class Pregunta
{
    public int Id { get; set; }

    public string Texto { get; set; } = null!;

    public decimal? Ponderacion { get; set; }

    public int? Idtipopregunta { get; set; }

    public int? Idevaluacion { get; set; }

    public string? Metajsonb { get; set; }

    public virtual Evaluacion? IdevaluacionNavigation { get; set; }

    public virtual Tipopreguntum? IdtipopreguntaNavigation { get; set; }

    public virtual ICollection<Opcionresrepuesta> Opcionresrepuesta { get; set; } = new List<Opcionresrepuesta>();

    public virtual ICollection<Repuestausuario> Repuestausuarios { get; set; } = new List<Repuestausuario>();
}
