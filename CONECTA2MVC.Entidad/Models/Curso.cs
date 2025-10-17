using System;
using System.Collections.Generic;

namespace CONECTA2MVC.Entidad.Models;

public partial class Curso
{
    public int Id { get; set; }

    public string Titulo { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public DateTime Fechapublicacion { get; set; }

    public DateTime Fechaactualizacion { get; set; }

    public bool? Estado { get; set; }

    public int? Idcategoriacurso { get; set; }

    public int? Idusuario { get; set; }

    public virtual ICollection<Evaluacion> Evaluacions { get; set; } = new List<Evaluacion>();

    public virtual ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();

    public virtual Categoriacurso? IdcategoriacursoNavigation { get; set; }

    public virtual Usuario? IdusuarioNavigation { get; set; }

    public virtual ICollection<Inscripcione> Inscripciones { get; set; } = new List<Inscripcione>();

    public virtual ICollection<Modulo> Modulos { get; set; } = new List<Modulo>();

    public virtual ICollection<Progresocurso> Progresocursos { get; set; } = new List<Progresocurso>();

    public virtual ICollection<Reconocimiento> Reconocimientos { get; set; } = new List<Reconocimiento>();

    public virtual ICollection<Videocurso> Videocursos { get; set; } = new List<Videocurso>();
}
