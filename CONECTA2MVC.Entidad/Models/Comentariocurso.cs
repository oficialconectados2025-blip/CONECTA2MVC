using System;
using System.Collections.Generic;

namespace CONECTA2MVC.Entidad.Models;

public partial class Comentariocurso
{
    public int Id { get; set; }

    public string Texto { get; set; } = null!;

    public DateTime Fechacomentado { get; set; }

    public int? Idusuario { get; set; }

    public int? Idvidcurso { get; set; }

    public virtual Usuario? IdusuarioNavigation { get; set; }

    public virtual Videocurso? IdvidcursoNavigation { get; set; }

    public virtual ICollection<Likecomcurso> Likecomcursos { get; set; } = new List<Likecomcurso>();
}
