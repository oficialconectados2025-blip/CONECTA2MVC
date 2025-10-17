using System;
using System.Collections.Generic;

namespace CONECTA2MVC.Entidad.Models;

public partial class Inscripcione
{
    public int Id { get; set; }

    public DateTime Fechainscripcion { get; set; }

    public string? Progresojson { get; set; }

    public bool? Estado { get; set; }

    public int? Idcurso { get; set; }

    public int? Idusuario { get; set; }

    public virtual Curso? IdcursoNavigation { get; set; }

    public virtual Usuario? IdusuarioNavigation { get; set; }
}
