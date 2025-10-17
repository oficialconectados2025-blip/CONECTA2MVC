using System;
using System.Collections.Generic;

namespace CONECTA2MVC.Entidad.Models;

public partial class Tipoenlaceprof
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Enlacesprofesor> Enlacesprofesors { get; set; } = new List<Enlacesprofesor>();
}
