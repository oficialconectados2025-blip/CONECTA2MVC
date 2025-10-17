using System;
using System.Collections.Generic;

namespace CONECTA2MVC.Entidad.Models;

public partial class Opcionresrepuesta
{
    public int Id { get; set; }

    public string? Texto { get; set; }

    public bool? Escorrecto { get; set; }

    public int? Orden { get; set; }

    public int? Idpreguntas { get; set; }

    public virtual Pregunta? IdpreguntasNavigation { get; set; }
}
