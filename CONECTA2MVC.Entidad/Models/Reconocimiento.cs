using System;
using System.Collections.Generic;

namespace CONECTA2MVC.Entidad.Models;

public partial class Reconocimiento
{
    public int Id { get; set; }

    public string Archivopdf { get; set; } = null!;

    public DateTime Fechaemision { get; set; }

    public string? Codigoverificacion { get; set; }

    public int? Idusuario { get; set; }

    public int? Idcurso { get; set; }

    public virtual Curso? IdcursoNavigation { get; set; }

    public virtual Usuario? IdusuarioNavigation { get; set; }
}
