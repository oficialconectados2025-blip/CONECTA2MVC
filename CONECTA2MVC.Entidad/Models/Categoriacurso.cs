using System;
using System.Collections.Generic;

namespace CONECTA2MVC.Entidad.Models;

public partial class Categoriacurso
{
    public int Id { get; set; }

    public string Nombcat { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public bool? Estado { get; set; }

    public virtual ICollection<Curso> Cursos { get; set; } = new List<Curso>();
}
