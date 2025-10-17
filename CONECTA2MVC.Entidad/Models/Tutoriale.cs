using System;
using System.Collections.Generic;

namespace CONECTA2MVC.Entidad.Models;

public partial class Tutoriale
{
    public int Id { get; set; }

    public string Titulo { get; set; } = null!;

    public DateTime? Fechacreacion { get; set; }

    public DateTime? Fechamodificacion { get; set; }

    public bool? Estado { get; set; }

    public int? Idusuario { get; set; }

    public virtual Usuario? IdusuarioNavigation { get; set; }

    public virtual ICollection<Videotutoriale> Videotutoriales { get; set; } = new List<Videotutoriale>();
}
