using System;
using System.Collections.Generic;

namespace CONECTA2MVC.Entidad.Models;

public partial class Usuario2fa
{
    public int Id { get; set; }

    public string? Tipo { get; set; }

    public string? Secreto { get; set; }

    public string? Ultimocodigo { get; set; }

    public bool? Activo { get; set; }

    public DateTime? Fechaactivacion { get; set; }

    public virtual Usuario IdNavigation { get; set; } = null!;
}
