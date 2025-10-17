using System;
using System.Collections.Generic;

namespace CONECTA2MVC.Entidad.Models;

public partial class Sugerenciacurso
{
    public int Id { get; set; }

    public string Titulo { get; set; } = null!;

    public string? Descripcion { get; set; }

    public string? Categoriasugerida { get; set; }

    public string? Estado { get; set; }

    public DateTime Fechasugerencia { get; set; }

    public int? Votos { get; set; }

    public int? Idusuario { get; set; }

    public virtual Usuario? IdusuarioNavigation { get; set; }

    public virtual ICollection<Votosugerencium> Votosugerencia { get; set; } = new List<Votosugerencium>();
}
