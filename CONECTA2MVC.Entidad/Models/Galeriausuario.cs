using System;
using System.Collections.Generic;

namespace CONECTA2MVC.Entidad.Models;

public partial class Galeriausuario
{
    public int Id { get; set; }

    public string Rutaarchivo { get; set; } = null!;

    public string? Descripcion { get; set; }

    public DateTime Fechasubidad { get; set; }

    public DateTime Fechainhabilitado { get; set; }

    public int Idusuario { get; set; }

    public virtual Usuario IdusuarioNavigation { get; set; } = null!;
}
