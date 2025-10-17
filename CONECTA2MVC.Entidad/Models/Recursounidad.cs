using System;
using System.Collections.Generic;

namespace CONECTA2MVC.Entidad.Models;

public partial class Recursounidad
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public string Archivo { get; set; } = null!;

    public string? Metajsonb { get; set; }

    public bool? Estado { get; set; }

    public int? Idtiporecurso { get; set; }

    public int? Idunidad { get; set; }

    public virtual Tiporecurso? IdtiporecursoNavigation { get; set; }

    public virtual Unidad? IdunidadNavigation { get; set; }
}
