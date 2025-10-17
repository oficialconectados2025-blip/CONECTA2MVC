using System;
using System.Collections.Generic;

namespace CONECTA2MVC.Entidad.Models;

public partial class Especialidad
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Profesorespecialidad> Profesorespecialidads { get; set; } = new List<Profesorespecialidad>();
}
