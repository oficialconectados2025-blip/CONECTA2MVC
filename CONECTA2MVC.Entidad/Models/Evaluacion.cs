using System;
using System.Collections.Generic;

namespace CONECTA2MVC.Entidad.Models;

public partial class Evaluacion
{
    public int Id { get; set; }

    public string Titulo { get; set; } = null!;

    public string Descripción { get; set; } = null!;

    public DateTime? Fechainicio { get; set; }

    public DateTime? Fechamodificacion { get; set; }

    public DateTime? Fechadisponibilidad { get; set; }

    public string? Configjson { get; set; }

    public int? Idcurso { get; set; }

    public int? Idtipoevaluacion { get; set; }

    public virtual ICollection<Actividad> Actividads { get; set; } = new List<Actividad>();

    public virtual Curso? IdcursoNavigation { get; set; }

    public virtual Tipoevaluacion? IdtipoevaluacionNavigation { get; set; }

    public virtual ICollection<Pregunta> Pregunta { get; set; } = new List<Pregunta>();
}
