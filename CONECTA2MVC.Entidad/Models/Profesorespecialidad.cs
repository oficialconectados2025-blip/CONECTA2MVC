using System;
using System.Collections.Generic;

namespace CONECTA2MVC.Entidad.Models;

public partial class Profesorespecialidad
{
    public int Id { get; set; }

    public int? Idprofesor { get; set; }

    public int? Idespecialidad { get; set; }

    public virtual Especialidad? IdespecialidadNavigation { get; set; }

    public virtual Profesor? IdprofesorNavigation { get; set; }
}
