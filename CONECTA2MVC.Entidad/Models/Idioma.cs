using System;
using System.Collections.Generic;

namespace CONECTA2MVC.Entidad.Models;

public partial class Idioma
{
    public int Id { get; set; }

    public string Idioma1 { get; set; } = null!;

    public virtual ICollection<Profesor> Profesors { get; set; } = new List<Profesor>();

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
