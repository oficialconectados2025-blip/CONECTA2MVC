using System;
using System.Collections.Generic;

namespace CONECTA2MVC.Entidad.Models;

public partial class Tituloprofesor
{
    public int Id { get; set; }

    public string Nombtitulo { get; set; } = null!;

    public string Institucion { get; set; } = null!;

    public DateTime Fechainicio { get; set; }

    public DateTime Fechafin { get; set; }

    public string Archivocomprobante { get; set; } = null!;

    public int? Idprofesor { get; set; }

    public virtual Profesor? IdprofesorNavigation { get; set; }
}
