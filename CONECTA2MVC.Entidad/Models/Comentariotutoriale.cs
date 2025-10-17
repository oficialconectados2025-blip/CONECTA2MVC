using System;
using System.Collections.Generic;

namespace CONECTA2MVC.Entidad.Models;

public partial class Comentariotutoriale
{
    public int Id { get; set; }

    public string Texto { get; set; } = null!;

    public DateTime? Fechacomentado { get; set; }

    public int? Idusuario { get; set; }

    public int? Idvideotutoriales { get; set; }

    public int? Idcomentariopadre { get; set; }

    public bool? Estado { get; set; }

    public virtual Comentariotutoriale? IdcomentariopadreNavigation { get; set; }

    public virtual Usuario? IdusuarioNavigation { get; set; }

    public virtual Videotutoriale? IdvideotutorialesNavigation { get; set; }

    public virtual ICollection<Comentariotutoriale> InverseIdcomentariopadreNavigation { get; set; } = new List<Comentariotutoriale>();

    public virtual ICollection<Likecomtutoriale> Likecomtutoriales { get; set; } = new List<Likecomtutoriale>();
}
