using System;
using System.Collections.Generic;

namespace CONECTA2MVC.Entidad.Models;

public partial class Modulo
{
    public int Id { get; set; }

    public string Titulo { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public int? Orden { get; set; }

    public int? Idcurso { get; set; }

    public virtual Curso? IdcursoNavigation { get; set; }

    public virtual ICollection<Unidad> Unidads { get; set; } = new List<Unidad>();
}
