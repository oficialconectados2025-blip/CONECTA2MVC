using System;
using System.Collections.Generic;

namespace CONECTA2MVC.Entidad.Models;

public partial class Enlacesprofesor
{
    public int Id { get; set; }

    public int? Tipoenlaceprof { get; set; }

    public string? Url { get; set; }

    public int? Idprofesor { get; set; }

    public virtual Profesor? IdprofesorNavigation { get; set; }

    public virtual Tipoenlaceprof? TipoenlaceprofNavigation { get; set; }
}
