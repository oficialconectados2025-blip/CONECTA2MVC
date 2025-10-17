using System;
using System.Collections.Generic;

namespace CONECTA2MVC.Entidad.Models;

public partial class Profesor
{
    public int Id { get; set; }

    public string Nombcompleto { get; set; } = null!;

    public string Correo { get; set; } = null!;

    public string Telefono { get; set; } = null!;

    public string Fax { get; set; } = null!;

    public string Disponibilidad { get; set; } = null!;

    public string ExperienciaGeneral { get; set; } = null!;

    public int? Idusuario { get; set; }

    public int? Ididioma { get; set; }

    public virtual ICollection<Actividad> Actividads { get; set; } = new List<Actividad>();

    public virtual ICollection<Enlacesprofesor> Enlacesprofesors { get; set; } = new List<Enlacesprofesor>();

    public virtual ICollection<Experiencialaboral> Experiencialaborals { get; set; } = new List<Experiencialaboral>();

    public virtual Idioma? IdidiomaNavigation { get; set; }

    public virtual Usuario? IdusuarioNavigation { get; set; }

    public virtual ICollection<Profesorespecialidad> Profesorespecialidads { get; set; } = new List<Profesorespecialidad>();

    public virtual ICollection<Tituloprofesor> Tituloprofesors { get; set; } = new List<Tituloprofesor>();
}
