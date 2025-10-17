using System;
using System.Collections.Generic;

namespace CONECTA2MVC.Entidad.Models;

public partial class Actividad
{
    public int Id { get; set; }

    public string Titulo { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public DateTime Fechapublicacion { get; set; }

    public DateTime Fechaentrega { get; set; }

    public bool? Permiteeditor { get; set; }

    public bool? Permitearchivos { get; set; }

    public string? Configjson { get; set; }

    public int? Idunidad { get; set; }

    public int? Idprofesor { get; set; }

    public int? Idtipoactividad { get; set; }

    public int? Idevaluacion { get; set; }

    public virtual ICollection<Archivosactividad> Archivosactividads { get; set; } = new List<Archivosactividad>();

    public virtual ICollection<Entregasactividad> Entregasactividads { get; set; } = new List<Entregasactividad>();

    public virtual Evaluacion? IdevaluacionNavigation { get; set; }

    public virtual Profesor? IdprofesorNavigation { get; set; }

    public virtual Tipoactividad? IdtipoactividadNavigation { get; set; }

    public virtual Unidad? IdunidadNavigation { get; set; }
}
