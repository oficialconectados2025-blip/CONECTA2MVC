using System;
using System.Collections.Generic;

namespace CONECTA2MVC.Entidad.Models;

public partial class Usuario
{
    public int Id { get; set; }

    public string Primernombre { get; set; } = null!;

    public string Segundonombre { get; set; } = null!;

    public string Primerapellido { get; set; } = null!;

    public string Segundoapellido { get; set; } = null!;

    public string Nombreusuario { get; set; } = null!;

    public string Contrasenia { get; set; } = null!;

    public string Telefono { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public string? Imgusuario { get; set; }

    public DateTime Fecharegistro { get; set; }

    public DateTime? Fechamodificacion { get; set; }

    public int? Idrol { get; set; }

    public int? Ididioma { get; set; }

    public virtual ICollection<Comentariocurso> Comentariocursos { get; set; } = new List<Comentariocurso>();

    public virtual ICollection<Comentarioforo> Comentarioforos { get; set; } = new List<Comentarioforo>();

    public virtual ICollection<Comentariotutoriale> Comentariotutoriales { get; set; } = new List<Comentariotutoriale>();

    public virtual ICollection<Curso> Cursos { get; set; } = new List<Curso>();

    public virtual ICollection<Entregasactividad> Entregasactividads { get; set; } = new List<Entregasactividad>();

    public virtual ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();

    public virtual ICollection<Galeriausuario> Galeriausuarios { get; set; } = new List<Galeriausuario>();

    public virtual ICollection<Hilosforo> Hilosforos { get; set; } = new List<Hilosforo>();

    public virtual Idioma? IdidiomaNavigation { get; set; }

    public virtual Rol? IdrolNavigation { get; set; }

    public virtual ICollection<Inscripcione> Inscripciones { get; set; } = new List<Inscripcione>();

    public virtual ICollection<Likecomcurso> Likecomcursos { get; set; } = new List<Likecomcurso>();

    public virtual ICollection<Likecomtutoriale> Likecomtutoriales { get; set; } = new List<Likecomtutoriale>();

    public virtual ICollection<Likevideocurso> Likevideocursos { get; set; } = new List<Likevideocurso>();

    public virtual ICollection<Likevideo> Likevideos { get; set; } = new List<Likevideo>();

    public virtual ICollection<Likevideotutoriale> Likevideotutoriales { get; set; } = new List<Likevideotutoriale>();

    public virtual ICollection<Notificacione> Notificaciones { get; set; } = new List<Notificacione>();

    public virtual ICollection<Pago> Pagos { get; set; } = new List<Pago>();

    public virtual ICollection<Profesor> Profesors { get; set; } = new List<Profesor>();

    public virtual ICollection<Progresocurso> Progresocursos { get; set; } = new List<Progresocurso>();

    public virtual ICollection<Progresounidad> Progresounidads { get; set; } = new List<Progresounidad>();

    public virtual ICollection<Reconocimiento> Reconocimientos { get; set; } = new List<Reconocimiento>();

    public virtual ICollection<Refreshtoken> Refreshtokens { get; set; } = new List<Refreshtoken>();

    public virtual ICollection<Registroactividad> Registroactividads { get; set; } = new List<Registroactividad>();

    public virtual ICollection<Repuestausuario> Repuestausuarios { get; set; } = new List<Repuestausuario>();

    public virtual ICollection<Seguidore> SeguidoreIdusuarioNavigations { get; set; } = new List<Seguidore>();

    public virtual ICollection<Seguidore> SeguidoreSeguidorusuarios { get; set; } = new List<Seguidore>();

    public virtual ICollection<Sugerenciacurso> Sugerenciacursos { get; set; } = new List<Sugerenciacurso>();

    public virtual ICollection<Suscripcione> Suscripciones { get; set; } = new List<Suscripcione>();

    public virtual ICollection<Tutoriale> Tutoriales { get; set; } = new List<Tutoriale>();

    public virtual Usuario2fa? Usuario2fa { get; set; }

    public virtual ICollection<Usuariooauth> Usuariooauths { get; set; } = new List<Usuariooauth>();

    public virtual ICollection<Videocurso> Videocursos { get; set; } = new List<Videocurso>();

    public virtual ICollection<Videotutoriale> Videotutoriales { get; set; } = new List<Videotutoriale>();

    public virtual ICollection<Votosugerencium> Votosugerencia { get; set; } = new List<Votosugerencium>();
}
