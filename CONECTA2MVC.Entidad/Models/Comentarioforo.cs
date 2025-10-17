using System;
using System.Collections.Generic;

namespace CONECTA2MVC.Entidad.Models;

public partial class Comentarioforo
{
    public int Id { get; set; }

    public string Contenido { get; set; } = null!;

    public DateTime Fechapublicacion { get; set; }

    public DateTime Fechamodificacion { get; set; }

    public int? Padrecomentario { get; set; }

    public int? Idhiloforo { get; set; }

    public int? Idusuario { get; set; }

    public virtual Hilosforo? IdhiloforoNavigation { get; set; }

    public virtual Usuario? IdusuarioNavigation { get; set; }

    public virtual ICollection<Comentarioforo> InversePadrecomentarioNavigation { get; set; } = new List<Comentarioforo>();

    public virtual Comentarioforo? PadrecomentarioNavigation { get; set; }
}
