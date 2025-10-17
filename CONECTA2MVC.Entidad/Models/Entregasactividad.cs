using System;
using System.Collections.Generic;

namespace CONECTA2MVC.Entidad.Models;

public partial class Entregasactividad
{
    public int Id { get; set; }

    public string? Textorepuesta { get; set; }

    public string? Rutaarchivo { get; set; }

    public DateTime? Fechaentrega { get; set; }

    public bool Estado { get; set; }

    public decimal? Calificaion { get; set; }

    public string? Feedback { get; set; }

    public int? Idactividad { get; set; }

    public int? Idusuario { get; set; }

    public virtual Actividad? IdactividadNavigation { get; set; }

    public virtual Usuario? IdusuarioNavigation { get; set; }
}
