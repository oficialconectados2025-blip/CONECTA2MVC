using System;
using System.Collections.Generic;

namespace CONECTA2MVC.Entidad.Models;

public partial class Hilosforo
{
    public int Id { get; set; }

    public string Titulo { get; set; } = null!;

    public string Contenido { get; set; } = null!;

    public DateTime Fechacreacion { get; set; }

    public DateTime Fechamodificacion { get; set; }

    public bool? Cerrado { get; set; }

    public int? Idusuario { get; set; }

    public int? Idforo { get; set; }

    public virtual ICollection<Comentarioforo> Comentarioforos { get; set; } = new List<Comentarioforo>();

    public virtual Foro? IdforoNavigation { get; set; }

    public virtual Usuario? IdusuarioNavigation { get; set; }
}
