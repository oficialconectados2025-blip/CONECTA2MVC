using System;
using System.Collections.Generic;

namespace CONECTA2MVC.Entidad.Models;

public partial class Plane
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public int? Duraciondias { get; set; }

    public decimal? Precio { get; set; }

    public string Descripcion { get; set; } = null!;

    public virtual ICollection<Pago> Pagos { get; set; } = new List<Pago>();

    public virtual ICollection<Suscripcione> Suscripciones { get; set; } = new List<Suscripcione>();
}
