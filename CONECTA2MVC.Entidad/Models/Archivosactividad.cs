using System;
using System.Collections.Generic;

namespace CONECTA2MVC.Entidad.Models;

public partial class Archivosactividad
{
    public int Id { get; set; }

    public string Rutaarchivo { get; set; } = null!;

    public string Nombrearchivo { get; set; } = null!;

    public string? Metajson { get; set; }

    public int? Idactividad { get; set; }

    public virtual Actividad? IdactividadNavigation { get; set; }
}
