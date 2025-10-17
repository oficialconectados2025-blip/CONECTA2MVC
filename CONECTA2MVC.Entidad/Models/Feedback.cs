using System;
using System.Collections.Generic;

namespace CONECTA2MVC.Entidad.Models;

public partial class Feedback
{
    public int Id { get; set; }

    public string? Texto { get; set; }

    public int? Calificacion { get; set; }

    public DateTime? Fecha { get; set; }

    public int? Idusuario { get; set; }

    public int? Idcurso { get; set; }

    public int? Idvideo { get; set; }

    public virtual Curso? IdcursoNavigation { get; set; }

    public virtual Usuario? IdusuarioNavigation { get; set; }

    public virtual Videocurso? IdvideoNavigation { get; set; }
}
