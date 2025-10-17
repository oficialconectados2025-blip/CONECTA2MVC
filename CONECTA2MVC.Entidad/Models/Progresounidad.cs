using System;
using System.Collections.Generic;

namespace CONECTA2MVC.Entidad.Models;

public partial class Progresounidad
{
    public int Id { get; set; }

    public decimal? Porcentaje { get; set; }

    public DateTime Fechainicio { get; set; }

    public DateTime Fechaactualizacion { get; set; }

    public int? Idunidad { get; set; }

    public int? Idusuario { get; set; }

    public virtual Unidad? IdunidadNavigation { get; set; }

    public virtual Usuario? IdusuarioNavigation { get; set; }
}
