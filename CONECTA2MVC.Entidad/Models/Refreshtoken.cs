using System;
using System.Collections.Generic;

namespace CONECTA2MVC.Entidad.Models;

public partial class Refreshtoken
{
    public int Id { get; set; }

    public int? Idusuario { get; set; }

    public string Token { get; set; } = null!;

    public DateTime? Fechaexpiracion { get; set; }

    public bool? Revocado { get; set; }

    public DateTime? Fechacreacion { get; set; }

    public virtual Usuario? IdusuarioNavigation { get; set; }
}
