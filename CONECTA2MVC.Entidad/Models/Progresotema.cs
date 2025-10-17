using System;
using System.Collections.Generic;

namespace CONECTA2MVC.Entidad.Models;

public partial class Progresotema
{
    public int Id { get; set; }

    public bool? Completado { get; set; }

    public DateTime Fechainiciado { get; set; }

    public DateTime Fechacompletado { get; set; }

    public int? Idtema { get; set; }

    public virtual Tema? IdtemaNavigation { get; set; }
}
