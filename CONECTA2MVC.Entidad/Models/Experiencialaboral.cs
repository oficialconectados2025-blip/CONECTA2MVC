using System;
using System.Collections.Generic;

namespace CONECTA2MVC.Entidad.Models;

public partial class Experiencialaboral
{
    public int Id { get; set; }

    public string Nombempresa { get; set; } = null!;

    public string Cargo { get; set; } = null!;

    public DateTime Fechainicio { get; set; }

    public DateTime Fechamodificacion { get; set; }

    public string Descripcion { get; set; } = null!;

    public string Archivocomprobante { get; set; } = null!;

    public int? Idprofesor { get; set; }

    public virtual Profesor? IdprofesorNavigation { get; set; }
}
