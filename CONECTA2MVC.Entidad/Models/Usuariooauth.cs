using System;
using System.Collections.Generic;

namespace CONECTA2MVC.Entidad.Models;

public partial class Usuariooauth
{
    public int Id { get; set; }

    public int? Idusuario { get; set; }

    public string? Proveedor { get; set; }

    public string? Identidadexterna { get; set; }

    public string? Accesstoken { get; set; }

    public string? Refreshtoken { get; set; }

    public DateTime? Fechaexpiracion { get; set; }

    public virtual Usuario? IdusuarioNavigation { get; set; }
}
