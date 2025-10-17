using System;
using System.Collections.Generic;

namespace CONECTA2MVC.Entidad.Models;

public partial class Videotutoriale
{
    public int Id { get; set; }

    public string Titulo { get; set; } = null!;

    public string? Descripcion { get; set; }

    public string Video { get; set; } = null!;

    public DateTime Fechapublicacion { get; set; }

    public DateTime Fechamodificacion { get; set; }

    public int? Idtutorial { get; set; }

    public int? Idusuario { get; set; }

    public virtual ICollection<Comentariotutoriale> Comentariotutoriales { get; set; } = new List<Comentariotutoriale>();

    public virtual Tutoriale? IdtutorialNavigation { get; set; }

    public virtual Usuario? IdusuarioNavigation { get; set; }

    public virtual ICollection<Likevideotutoriale> Likevideotutoriales { get; set; } = new List<Likevideotutoriale>();
}
