using System;
using System.Collections.Generic;

namespace CONECTA2MVC.Entidad.Models;

public partial class Repuestausuario
{
    public int Id { get; set; }

    public string? Seleccionado { get; set; }

    public DateTime? Fecharepuesta { get; set; }

    public decimal? Calificacion { get; set; }

    public int? Idusuario { get; set; }

    public int? Idpreguntas { get; set; }

    public virtual Pregunta? IdpreguntasNavigation { get; set; }

    public virtual Usuario? IdusuarioNavigation { get; set; }
}
