using System;
using System.Collections.Generic;

namespace CONECTA2MVC.Entidad.Models;

public partial class Videocurso
{
    public int Id { get; set; }

    public string Titulo { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public string Rutaarchivo { get; set; } = null!;

    public DateTime? Fechapublicacion { get; set; }

    public DateTime? Fechamodificación { get; set; }

    public int? Publicadopor { get; set; }

    public int? Idcurso { get; set; }

    public bool? Estado { get; set; }

    public virtual ICollection<Comentariocurso> Comentariocursos { get; set; } = new List<Comentariocurso>();

    public virtual ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();

    public virtual Curso? IdcursoNavigation { get; set; }

    public virtual ICollection<Likevideocurso> Likevideocursos { get; set; } = new List<Likevideocurso>();

    public virtual ICollection<Likevideo> Likevideos { get; set; } = new List<Likevideo>();

    public virtual Usuario? PublicadoporNavigation { get; set; }
}
