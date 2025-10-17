using System;
using System.Collections.Generic;
using CONECTA2MVC.Entidad.Models;
using Microsoft.EntityFrameworkCore;

namespace CONECTA2MVC.Datos.DBContextCONECTA2;

public partial class DBContextConecta2 : DbContext
{
    public DBContextConecta2()
    {
    }

    public DBContextConecta2(DbContextOptions<DBContextConecta2> options)
        : base(options)
    {
    }

    public virtual DbSet<Actividad> Actividads { get; set; }

    public virtual DbSet<Archivosactividad> Archivosactividads { get; set; }

    public virtual DbSet<Categoriacurso> Categoriacursos { get; set; }

    public virtual DbSet<Comentariocurso> Comentariocursos { get; set; }

    public virtual DbSet<Comentarioforo> Comentarioforos { get; set; }

    public virtual DbSet<Comentariotutoriale> Comentariotutoriales { get; set; }

    public virtual DbSet<Curso> Cursos { get; set; }

    public virtual DbSet<Enlacesprofesor> Enlacesprofesors { get; set; }

    public virtual DbSet<Entregasactividad> Entregasactividads { get; set; }

    public virtual DbSet<Especialidad> Especialidads { get; set; }

    public virtual DbSet<Evaluacion> Evaluacions { get; set; }

    public virtual DbSet<Experiencialaboral> Experiencialaborals { get; set; }

    public virtual DbSet<Feedback> Feedbacks { get; set; }

    public virtual DbSet<Foro> Foros { get; set; }

    public virtual DbSet<Galeriausuario> Galeriausuarios { get; set; }

    public virtual DbSet<Hilosforo> Hilosforos { get; set; }

    public virtual DbSet<Idioma> Idiomas { get; set; }

    public virtual DbSet<Inscripcione> Inscripciones { get; set; }

    public virtual DbSet<Likecomcurso> Likecomcursos { get; set; }

    public virtual DbSet<Likecomtutoriale> Likecomtutoriales { get; set; }

    public virtual DbSet<Likevideo> Likevideos { get; set; }

    public virtual DbSet<Likevideocurso> Likevideocursos { get; set; }

    public virtual DbSet<Likevideotutoriale> Likevideotutoriales { get; set; }

    public virtual DbSet<Modulo> Modulos { get; set; }

    public virtual DbSet<Notificacione> Notificaciones { get; set; }

    public virtual DbSet<Opcionresrepuesta> Opcionresrepuestas { get; set; }

    public virtual DbSet<Pago> Pagos { get; set; }

    public virtual DbSet<Plane> Planes { get; set; }

    public virtual DbSet<Pregunta> Preguntas { get; set; }

    public virtual DbSet<Profesor> Profesors { get; set; }

    public virtual DbSet<Profesorespecialidad> Profesorespecialidads { get; set; }

    public virtual DbSet<Progresocurso> Progresocursos { get; set; }

    public virtual DbSet<Progresotema> Progresotemas { get; set; }

    public virtual DbSet<Progresounidad> Progresounidads { get; set; }

    public virtual DbSet<Reconocimiento> Reconocimientos { get; set; }

    public virtual DbSet<Recursounidad> Recursounidads { get; set; }

    public virtual DbSet<Refreshtoken> Refreshtokens { get; set; }

    public virtual DbSet<Registroactividad> Registroactividads { get; set; }

    public virtual DbSet<Repuestausuario> Repuestausuarios { get; set; }

    public virtual DbSet<Rol> Rols { get; set; }

    public virtual DbSet<Seguidore> Seguidores { get; set; }

    public virtual DbSet<Sugerenciacurso> Sugerenciacursos { get; set; }

    public virtual DbSet<Suscripcione> Suscripciones { get; set; }

    public virtual DbSet<Tema> Temas { get; set; }

    public virtual DbSet<Tipoactividad> Tipoactividads { get; set; }

    public virtual DbSet<Tipoenlaceprof> Tipoenlaceprofs { get; set; }

    public virtual DbSet<Tipoevaluacion> Tipoevaluacions { get; set; }

    public virtual DbSet<Tipopreguntum> Tipopregunta { get; set; }

    public virtual DbSet<Tiporecurso> Tiporecursos { get; set; }

    public virtual DbSet<Tituloprofesor> Tituloprofesors { get; set; }

    public virtual DbSet<Tutoriale> Tutoriales { get; set; }

    public virtual DbSet<Unidad> Unidads { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<Usuario2fa> Usuario2fas { get; set; }

    public virtual DbSet<Usuariooauth> Usuariooauths { get; set; }

    public virtual DbSet<Videocurso> Videocursos { get; set; }

    public virtual DbSet<Videotutoriale> Videotutoriales { get; set; }

    public virtual DbSet<Votosugerencium> Votosugerencia { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Actividad>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("actividad_pkey");

            entity.ToTable("actividad");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Configjson)
                .HasColumnType("jsonb")
                .HasColumnName("configjson");
            entity.Property(e => e.Descripcion).HasColumnName("descripcion");
            entity.Property(e => e.Fechaentrega)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fechaentrega");
            entity.Property(e => e.Fechapublicacion)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fechapublicacion");
            entity.Property(e => e.Idevaluacion).HasColumnName("idevaluacion");
            entity.Property(e => e.Idprofesor).HasColumnName("idprofesor");
            entity.Property(e => e.Idtipoactividad).HasColumnName("idtipoactividad");
            entity.Property(e => e.Idunidad).HasColumnName("idunidad");
            entity.Property(e => e.Permitearchivos)
                .HasDefaultValue(true)
                .HasColumnName("permitearchivos");
            entity.Property(e => e.Permiteeditor)
                .HasDefaultValue(true)
                .HasColumnName("permiteeditor");
            entity.Property(e => e.Titulo)
                .HasMaxLength(150)
                .HasColumnName("titulo");

            entity.HasOne(d => d.IdevaluacionNavigation).WithMany(p => p.Actividads)
                .HasForeignKey(d => d.Idevaluacion)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("actividad_idevaluacion_fkey");

            entity.HasOne(d => d.IdprofesorNavigation).WithMany(p => p.Actividads)
                .HasForeignKey(d => d.Idprofesor)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("actividad_idprofesor_fkey");

            entity.HasOne(d => d.IdtipoactividadNavigation).WithMany(p => p.Actividads)
                .HasForeignKey(d => d.Idtipoactividad)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("actividad_idtipoactividad_fkey");

            entity.HasOne(d => d.IdunidadNavigation).WithMany(p => p.Actividads)
                .HasForeignKey(d => d.Idunidad)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("actividad_idunidad_fkey");
        });

        modelBuilder.Entity<Archivosactividad>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("archivosactividad_pkey");

            entity.ToTable("archivosactividad");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Idactividad).HasColumnName("idactividad");
            entity.Property(e => e.Metajson)
                .HasColumnType("jsonb")
                .HasColumnName("metajson");
            entity.Property(e => e.Nombrearchivo)
                .HasMaxLength(200)
                .HasColumnName("nombrearchivo");
            entity.Property(e => e.Rutaarchivo).HasColumnName("rutaarchivo");

            entity.HasOne(d => d.IdactividadNavigation).WithMany(p => p.Archivosactividads)
                .HasForeignKey(d => d.Idactividad)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("archivosactividad_idactividad_fkey");
        });

        modelBuilder.Entity<Categoriacurso>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("categoriacurso_pkey");

            entity.ToTable("categoriacurso");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(250)
                .HasColumnName("descripcion");
            entity.Property(e => e.Estado)
                .HasDefaultValue(true)
                .HasColumnName("estado");
            entity.Property(e => e.Nombcat)
                .HasMaxLength(150)
                .HasColumnName("nombcat");
        });

        modelBuilder.Entity<Comentariocurso>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("comentariocurso_pkey");

            entity.ToTable("comentariocurso");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Fechacomentado)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fechacomentado");
            entity.Property(e => e.Idusuario).HasColumnName("idusuario");
            entity.Property(e => e.Idvidcurso).HasColumnName("idvidcurso");
            entity.Property(e => e.Texto)
                .HasMaxLength(400)
                .HasColumnName("texto");

            entity.HasOne(d => d.IdusuarioNavigation).WithMany(p => p.Comentariocursos)
                .HasForeignKey(d => d.Idusuario)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("comentariocurso_idusuario_fkey");

            entity.HasOne(d => d.IdvidcursoNavigation).WithMany(p => p.Comentariocursos)
                .HasForeignKey(d => d.Idvidcurso)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("comentariocurso_idvidcurso_fkey");
        });

        modelBuilder.Entity<Comentarioforo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("comentarioforo_pkey");

            entity.ToTable("comentarioforo");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Contenido)
                .HasMaxLength(340)
                .HasColumnName("contenido");
            entity.Property(e => e.Fechamodificacion)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fechamodificacion");
            entity.Property(e => e.Fechapublicacion)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fechapublicacion");
            entity.Property(e => e.Idhiloforo).HasColumnName("idhiloforo");
            entity.Property(e => e.Idusuario).HasColumnName("idusuario");
            entity.Property(e => e.Padrecomentario).HasColumnName("padrecomentario");

            entity.HasOne(d => d.IdhiloforoNavigation).WithMany(p => p.Comentarioforos)
                .HasForeignKey(d => d.Idhiloforo)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("comentarioforo_idhiloforo_fkey");

            entity.HasOne(d => d.IdusuarioNavigation).WithMany(p => p.Comentarioforos)
                .HasForeignKey(d => d.Idusuario)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("comentarioforo_idusuario_fkey");

            entity.HasOne(d => d.PadrecomentarioNavigation).WithMany(p => p.InversePadrecomentarioNavigation)
                .HasForeignKey(d => d.Padrecomentario)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("comentarioforo_padrecomentario_fkey");
        });

        modelBuilder.Entity<Comentariotutoriale>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("comentariotutoriales_pkey");

            entity.ToTable("comentariotutoriales");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Estado)
                .HasDefaultValue(true)
                .HasColumnName("estado");
            entity.Property(e => e.Fechacomentado)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fechacomentado");
            entity.Property(e => e.Idcomentariopadre).HasColumnName("idcomentariopadre");
            entity.Property(e => e.Idusuario).HasColumnName("idusuario");
            entity.Property(e => e.Idvideotutoriales).HasColumnName("idvideotutoriales");
            entity.Property(e => e.Texto).HasColumnName("texto");

            entity.HasOne(d => d.IdcomentariopadreNavigation).WithMany(p => p.InverseIdcomentariopadreNavigation)
                .HasForeignKey(d => d.Idcomentariopadre)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("comentariotutoriales_idcomentariopadre_fkey");

            entity.HasOne(d => d.IdusuarioNavigation).WithMany(p => p.Comentariotutoriales)
                .HasForeignKey(d => d.Idusuario)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("comentariotutoriales_idusuario_fkey");

            entity.HasOne(d => d.IdvideotutorialesNavigation).WithMany(p => p.Comentariotutoriales)
                .HasForeignKey(d => d.Idvideotutoriales)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("comentariotutoriales_idvideotutoriales_fkey");
        });

        modelBuilder.Entity<Curso>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("curso_pkey");

            entity.ToTable("curso");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(250)
                .HasColumnName("descripcion");
            entity.Property(e => e.Estado)
                .HasDefaultValue(true)
                .HasColumnName("estado");
            entity.Property(e => e.Fechaactualizacion)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fechaactualizacion");
            entity.Property(e => e.Fechapublicacion)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fechapublicacion");
            entity.Property(e => e.Idcategoriacurso).HasColumnName("idcategoriacurso");
            entity.Property(e => e.Idusuario).HasColumnName("idusuario");
            entity.Property(e => e.Titulo)
                .HasMaxLength(155)
                .HasColumnName("titulo");

            entity.HasOne(d => d.IdcategoriacursoNavigation).WithMany(p => p.Cursos)
                .HasForeignKey(d => d.Idcategoriacurso)
                .HasConstraintName("curso_idcategoriacurso_fkey");

            entity.HasOne(d => d.IdusuarioNavigation).WithMany(p => p.Cursos)
                .HasForeignKey(d => d.Idusuario)
                .HasConstraintName("curso_idusuario_fkey");
        });

        modelBuilder.Entity<Enlacesprofesor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("enlacesprofesor_pkey");

            entity.ToTable("enlacesprofesor");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Idprofesor).HasColumnName("idprofesor");
            entity.Property(e => e.Tipoenlaceprof).HasColumnName("tipoenlaceprof");
            entity.Property(e => e.Url).HasColumnName("url");

            entity.HasOne(d => d.IdprofesorNavigation).WithMany(p => p.Enlacesprofesors)
                .HasForeignKey(d => d.Idprofesor)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("enlacesprofesor_idprofesor_fkey");

            entity.HasOne(d => d.TipoenlaceprofNavigation).WithMany(p => p.Enlacesprofesors)
                .HasForeignKey(d => d.Tipoenlaceprof)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("enlacesprofesor_tipoenlaceprof_fkey");
        });

        modelBuilder.Entity<Entregasactividad>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("entregasactividad_pkey");

            entity.ToTable("entregasactividad");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Calificaion)
                .HasPrecision(5, 2)
                .HasColumnName("calificaion");
            entity.Property(e => e.Estado)
                .HasDefaultValue(false)
                .HasColumnName("estado");
            entity.Property(e => e.Fechaentrega)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fechaentrega");
            entity.Property(e => e.Feedback).HasColumnName("feedback");
            entity.Property(e => e.Idactividad).HasColumnName("idactividad");
            entity.Property(e => e.Idusuario).HasColumnName("idusuario");
            entity.Property(e => e.Rutaarchivo).HasColumnName("rutaarchivo");
            entity.Property(e => e.Textorepuesta)
                .HasMaxLength(600)
                .HasColumnName("textorepuesta");

            entity.HasOne(d => d.IdactividadNavigation).WithMany(p => p.Entregasactividads)
                .HasForeignKey(d => d.Idactividad)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("entregasactividad_idactividad_fkey");

            entity.HasOne(d => d.IdusuarioNavigation).WithMany(p => p.Entregasactividads)
                .HasForeignKey(d => d.Idusuario)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("entregasactividad_idusuario_fkey");
        });

        modelBuilder.Entity<Especialidad>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("especialidad_pkey");

            entity.ToTable("especialidad");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nombre)
                .HasMaxLength(150)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Evaluacion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("evaluacion_pkey");

            entity.ToTable("evaluacion");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Configjson)
                .HasColumnType("jsonb")
                .HasColumnName("configjson");
            entity.Property(e => e.Descripción)
                .HasMaxLength(250)
                .HasColumnName("descripción");
            entity.Property(e => e.Fechadisponibilidad)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fechadisponibilidad");
            entity.Property(e => e.Fechainicio)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fechainicio");
            entity.Property(e => e.Fechamodificacion)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fechamodificacion");
            entity.Property(e => e.Idcurso).HasColumnName("idcurso");
            entity.Property(e => e.Idtipoevaluacion).HasColumnName("idtipoevaluacion");
            entity.Property(e => e.Titulo)
                .HasMaxLength(120)
                .HasColumnName("titulo");

            entity.HasOne(d => d.IdcursoNavigation).WithMany(p => p.Evaluacions)
                .HasForeignKey(d => d.Idcurso)
                .HasConstraintName("evaluacion_idcurso_fkey");

            entity.HasOne(d => d.IdtipoevaluacionNavigation).WithMany(p => p.Evaluacions)
                .HasForeignKey(d => d.Idtipoevaluacion)
                .HasConstraintName("evaluacion_idtipoevaluacion_fkey");
        });

        modelBuilder.Entity<Experiencialaboral>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("experiencialaboral_pkey");

            entity.ToTable("experiencialaboral");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Archivocomprobante).HasColumnName("archivocomprobante");
            entity.Property(e => e.Cargo)
                .HasMaxLength(60)
                .HasColumnName("cargo");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(250)
                .HasColumnName("descripcion");
            entity.Property(e => e.Fechainicio)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fechainicio");
            entity.Property(e => e.Fechamodificacion)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fechamodificacion");
            entity.Property(e => e.Idprofesor).HasColumnName("idprofesor");
            entity.Property(e => e.Nombempresa)
                .HasMaxLength(60)
                .HasColumnName("nombempresa");

            entity.HasOne(d => d.IdprofesorNavigation).WithMany(p => p.Experiencialaborals)
                .HasForeignKey(d => d.Idprofesor)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("experiencialaboral_idprofesor_fkey");
        });

        modelBuilder.Entity<Feedback>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("feedback_pkey");

            entity.ToTable("feedback");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Calificacion).HasColumnName("calificacion");
            entity.Property(e => e.Fecha)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fecha");
            entity.Property(e => e.Idcurso).HasColumnName("idcurso");
            entity.Property(e => e.Idusuario).HasColumnName("idusuario");
            entity.Property(e => e.Idvideo).HasColumnName("idvideo");
            entity.Property(e => e.Texto).HasColumnName("texto");

            entity.HasOne(d => d.IdcursoNavigation).WithMany(p => p.Feedbacks)
                .HasForeignKey(d => d.Idcurso)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("feedback_idcurso_fkey");

            entity.HasOne(d => d.IdusuarioNavigation).WithMany(p => p.Feedbacks)
                .HasForeignKey(d => d.Idusuario)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("feedback_idusuario_fkey");

            entity.HasOne(d => d.IdvideoNavigation).WithMany(p => p.Feedbacks)
                .HasForeignKey(d => d.Idvideo)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("feedback_idvideo_fkey");
        });

        modelBuilder.Entity<Foro>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("foros_pkey");

            entity.ToTable("foros");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Descripcino)
                .HasMaxLength(250)
                .HasColumnName("descripcino");
            entity.Property(e => e.Fechacreacion)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fechacreacion");
            entity.Property(e => e.Fechamodificacion)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fechamodificacion");
            entity.Property(e => e.Idunidad).HasColumnName("idunidad");
            entity.Property(e => e.Titulo)
                .HasMaxLength(150)
                .HasColumnName("titulo");

            entity.HasOne(d => d.IdunidadNavigation).WithMany(p => p.Foros)
                .HasForeignKey(d => d.Idunidad)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("foros_idunidad_fkey");
        });

        modelBuilder.Entity<Galeriausuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("galeriausuario_pkey");

            entity.ToTable("galeriausuario");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(250)
                .HasColumnName("descripcion");
            entity.Property(e => e.Fechainhabilitado)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fechainhabilitado");
            entity.Property(e => e.Fechasubidad)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fechasubidad");
            entity.Property(e => e.Idusuario).HasColumnName("idusuario");
            entity.Property(e => e.Rutaarchivo).HasColumnName("rutaarchivo");

            entity.HasOne(d => d.IdusuarioNavigation).WithMany(p => p.Galeriausuarios)
                .HasForeignKey(d => d.Idusuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("galeriausuario_idusuario_fkey");
        });

        modelBuilder.Entity<Hilosforo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("hilosforos_pkey");

            entity.ToTable("hilosforos");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Cerrado)
                .HasDefaultValue(true)
                .HasColumnName("cerrado");
            entity.Property(e => e.Contenido)
                .HasMaxLength(300)
                .HasColumnName("contenido");
            entity.Property(e => e.Fechacreacion)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fechacreacion");
            entity.Property(e => e.Fechamodificacion)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fechamodificacion");
            entity.Property(e => e.Idforo).HasColumnName("idforo");
            entity.Property(e => e.Idusuario).HasColumnName("idusuario");
            entity.Property(e => e.Titulo)
                .HasMaxLength(150)
                .HasColumnName("titulo");

            entity.HasOne(d => d.IdforoNavigation).WithMany(p => p.Hilosforos)
                .HasForeignKey(d => d.Idforo)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("hilosforos_idforo_fkey");

            entity.HasOne(d => d.IdusuarioNavigation).WithMany(p => p.Hilosforos)
                .HasForeignKey(d => d.Idusuario)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("hilosforos_idusuario_fkey");
        });

        modelBuilder.Entity<Idioma>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("idiomas_pkey");

            entity.ToTable("idiomas");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Idioma1)
                .HasMaxLength(75)
                .HasColumnName("idioma");
        });

        modelBuilder.Entity<Inscripcione>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("inscripciones_pkey");

            entity.ToTable("inscripciones");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Estado)
                .HasDefaultValue(true)
                .HasColumnName("estado");
            entity.Property(e => e.Fechainscripcion)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fechainscripcion");
            entity.Property(e => e.Idcurso).HasColumnName("idcurso");
            entity.Property(e => e.Idusuario).HasColumnName("idusuario");
            entity.Property(e => e.Progresojson)
                .HasColumnType("jsonb")
                .HasColumnName("progresojson");

            entity.HasOne(d => d.IdcursoNavigation).WithMany(p => p.Inscripciones)
                .HasForeignKey(d => d.Idcurso)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("inscripciones_idcurso_fkey");

            entity.HasOne(d => d.IdusuarioNavigation).WithMany(p => p.Inscripciones)
                .HasForeignKey(d => d.Idusuario)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("inscripciones_idusuario_fkey");
        });

        modelBuilder.Entity<Likecomcurso>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("likecomcurso_pkey");

            entity.ToTable("likecomcurso");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Idcomentariocurso).HasColumnName("idcomentariocurso");
            entity.Property(e => e.Idusuario).HasColumnName("idusuario");

            entity.HasOne(d => d.IdcomentariocursoNavigation).WithMany(p => p.Likecomcursos)
                .HasForeignKey(d => d.Idcomentariocurso)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("likecomcurso_idcomentariocurso_fkey");

            entity.HasOne(d => d.IdusuarioNavigation).WithMany(p => p.Likecomcursos)
                .HasForeignKey(d => d.Idusuario)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("likecomcurso_idusuario_fkey");
        });

        modelBuilder.Entity<Likecomtutoriale>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("likecomtutoriales_pkey");

            entity.ToTable("likecomtutoriales");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Fecha)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fecha");
            entity.Property(e => e.Idcomentariotuto).HasColumnName("idcomentariotuto");
            entity.Property(e => e.Idusuario).HasColumnName("idusuario");

            entity.HasOne(d => d.IdcomentariotutoNavigation).WithMany(p => p.Likecomtutoriales)
                .HasForeignKey(d => d.Idcomentariotuto)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("likecomtutoriales_idcomentariotuto_fkey");

            entity.HasOne(d => d.IdusuarioNavigation).WithMany(p => p.Likecomtutoriales)
                .HasForeignKey(d => d.Idusuario)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("likecomtutoriales_idusuario_fkey");
        });

        modelBuilder.Entity<Likevideo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("likevideo_pkey");

            entity.ToTable("likevideo");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Idusuario).HasColumnName("idusuario");
            entity.Property(e => e.Idvideocurso).HasColumnName("idvideocurso");

            entity.HasOne(d => d.IdusuarioNavigation).WithMany(p => p.Likevideos)
                .HasForeignKey(d => d.Idusuario)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("likevideo_idusuario_fkey");

            entity.HasOne(d => d.IdvideocursoNavigation).WithMany(p => p.Likevideos)
                .HasForeignKey(d => d.Idvideocurso)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("likevideo_idvideocurso_fkey");
        });

        modelBuilder.Entity<Likevideocurso>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("likevideocurso_pkey");

            entity.ToTable("likevideocurso");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Idusuario).HasColumnName("idusuario");
            entity.Property(e => e.Idvideocurso).HasColumnName("idvideocurso");

            entity.HasOne(d => d.IdusuarioNavigation).WithMany(p => p.Likevideocursos)
                .HasForeignKey(d => d.Idusuario)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("likevideocurso_idusuario_fkey");

            entity.HasOne(d => d.IdvideocursoNavigation).WithMany(p => p.Likevideocursos)
                .HasForeignKey(d => d.Idvideocurso)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("likevideocurso_idvideocurso_fkey");
        });

        modelBuilder.Entity<Likevideotutoriale>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("likevideotutoriales_pkey");

            entity.ToTable("likevideotutoriales");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Fecha)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fecha");
            entity.Property(e => e.Idusuario).HasColumnName("idusuario");
            entity.Property(e => e.Idvidtutorial).HasColumnName("idvidtutorial");

            entity.HasOne(d => d.IdusuarioNavigation).WithMany(p => p.Likevideotutoriales)
                .HasForeignKey(d => d.Idusuario)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("likevideotutoriales_idusuario_fkey");

            entity.HasOne(d => d.IdvidtutorialNavigation).WithMany(p => p.Likevideotutoriales)
                .HasForeignKey(d => d.Idvidtutorial)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("likevideotutoriales_idvidtutorial_fkey");
        });

        modelBuilder.Entity<Modulo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("modulos_pkey");

            entity.ToTable("modulos");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(250)
                .HasColumnName("descripcion");
            entity.Property(e => e.Idcurso).HasColumnName("idcurso");
            entity.Property(e => e.Orden).HasColumnName("orden");
            entity.Property(e => e.Titulo)
                .HasMaxLength(150)
                .HasColumnName("titulo");

            entity.HasOne(d => d.IdcursoNavigation).WithMany(p => p.Modulos)
                .HasForeignKey(d => d.Idcurso)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("modulos_idcurso_fkey");
        });

        modelBuilder.Entity<Notificacione>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("notificaciones_pkey");

            entity.ToTable("notificaciones");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Fechaenviado)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fechaenviado");
            entity.Property(e => e.Idusuario).HasColumnName("idusuario");
            entity.Property(e => e.Leido)
                .HasDefaultValue(false)
                .HasColumnName("leido");
            entity.Property(e => e.Mensaje).HasColumnName("mensaje");
            entity.Property(e => e.Tipo)
                .HasMaxLength(130)
                .HasColumnName("tipo");

            entity.HasOne(d => d.IdusuarioNavigation).WithMany(p => p.Notificaciones)
                .HasForeignKey(d => d.Idusuario)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("notificaciones_idusuario_fkey");
        });

        modelBuilder.Entity<Opcionresrepuesta>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("opcionresrepuestas_pkey");

            entity.ToTable("opcionresrepuestas");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Escorrecto)
                .HasDefaultValue(false)
                .HasColumnName("escorrecto");
            entity.Property(e => e.Idpreguntas).HasColumnName("idpreguntas");
            entity.Property(e => e.Orden).HasColumnName("orden");
            entity.Property(e => e.Texto).HasColumnName("texto");

            entity.HasOne(d => d.IdpreguntasNavigation).WithMany(p => p.Opcionresrepuesta)
                .HasForeignKey(d => d.Idpreguntas)
                .HasConstraintName("opcionresrepuestas_idpreguntas_fkey");
        });

        modelBuilder.Entity<Pago>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pagos_pkey");

            entity.ToTable("pagos");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Fechapago)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fechapago");
            entity.Property(e => e.Idplan).HasColumnName("idplan");
            entity.Property(e => e.Idtransaccion)
                .HasMaxLength(160)
                .HasColumnName("idtransaccion");
            entity.Property(e => e.Idusuario).HasColumnName("idusuario");
            entity.Property(e => e.Metodopago)
                .HasMaxLength(200)
                .HasColumnName("metodopago");
            entity.Property(e => e.Monto)
                .HasPrecision(10, 2)
                .HasColumnName("monto");

            entity.HasOne(d => d.IdplanNavigation).WithMany(p => p.Pagos)
                .HasForeignKey(d => d.Idplan)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("pagos_idplan_fkey");

            entity.HasOne(d => d.IdusuarioNavigation).WithMany(p => p.Pagos)
                .HasForeignKey(d => d.Idusuario)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("pagos_idusuario_fkey");
        });

        modelBuilder.Entity<Plane>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("planes_pkey");

            entity.ToTable("planes");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Descripcion).HasColumnName("descripcion");
            entity.Property(e => e.Duraciondias).HasColumnName("duraciondias");
            entity.Property(e => e.Nombre)
                .HasMaxLength(150)
                .HasColumnName("nombre");
            entity.Property(e => e.Precio)
                .HasPrecision(10, 2)
                .HasColumnName("precio");
        });

        modelBuilder.Entity<Pregunta>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("preguntas_pkey");

            entity.ToTable("preguntas");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Idevaluacion).HasColumnName("idevaluacion");
            entity.Property(e => e.Idtipopregunta).HasColumnName("idtipopregunta");
            entity.Property(e => e.Metajsonb)
                .HasColumnType("jsonb")
                .HasColumnName("metajsonb");
            entity.Property(e => e.Ponderacion)
                .HasPrecision(5, 2)
                .HasColumnName("ponderacion");
            entity.Property(e => e.Texto)
                .HasMaxLength(170)
                .HasColumnName("texto");

            entity.HasOne(d => d.IdevaluacionNavigation).WithMany(p => p.Pregunta)
                .HasForeignKey(d => d.Idevaluacion)
                .HasConstraintName("preguntas_idevaluacion_fkey");

            entity.HasOne(d => d.IdtipopreguntaNavigation).WithMany(p => p.Pregunta)
                .HasForeignKey(d => d.Idtipopregunta)
                .HasConstraintName("preguntas_idtipopregunta_fkey");
        });

        modelBuilder.Entity<Profesor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("profesor_pkey");

            entity.ToTable("profesor");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Correo)
                .HasMaxLength(200)
                .HasColumnName("correo");
            entity.Property(e => e.Disponibilidad)
                .HasMaxLength(100)
                .HasColumnName("disponibilidad");
            entity.Property(e => e.ExperienciaGeneral).HasColumnName("experiencia_general");
            entity.Property(e => e.Fax)
                .HasMaxLength(30)
                .HasColumnName("fax");
            entity.Property(e => e.Ididioma).HasColumnName("ididioma");
            entity.Property(e => e.Idusuario).HasColumnName("idusuario");
            entity.Property(e => e.Nombcompleto)
                .HasMaxLength(200)
                .HasColumnName("nombcompleto");
            entity.Property(e => e.Telefono)
                .HasMaxLength(25)
                .HasColumnName("telefono");

            entity.HasOne(d => d.IdidiomaNavigation).WithMany(p => p.Profesors)
                .HasForeignKey(d => d.Ididioma)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("profesor_ididioma_fkey");

            entity.HasOne(d => d.IdusuarioNavigation).WithMany(p => p.Profesors)
                .HasForeignKey(d => d.Idusuario)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("profesor_idusuario_fkey");
        });

        modelBuilder.Entity<Profesorespecialidad>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("profesorespecialidad_pkey");

            entity.ToTable("profesorespecialidad");

            entity.HasIndex(e => new { e.Idprofesor, e.Idespecialidad }, "profesorespecialidad_idprofesor_idespecialidad_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Idespecialidad).HasColumnName("idespecialidad");
            entity.Property(e => e.Idprofesor).HasColumnName("idprofesor");

            entity.HasOne(d => d.IdespecialidadNavigation).WithMany(p => p.Profesorespecialidads)
                .HasForeignKey(d => d.Idespecialidad)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("profesorespecialidad_idespecialidad_fkey");

            entity.HasOne(d => d.IdprofesorNavigation).WithMany(p => p.Profesorespecialidads)
                .HasForeignKey(d => d.Idprofesor)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("profesorespecialidad_idprofesor_fkey");
        });

        modelBuilder.Entity<Progresocurso>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("progresocurso_pkey");

            entity.ToTable("progresocurso");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Fechaactualizacion)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fechaactualizacion");
            entity.Property(e => e.Fechainicio)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fechainicio");
            entity.Property(e => e.Idcurso).HasColumnName("idcurso");
            entity.Property(e => e.Idusuario).HasColumnName("idusuario");
            entity.Property(e => e.Porcentaje)
                .HasPrecision(5, 2)
                .HasColumnName("porcentaje");

            entity.HasOne(d => d.IdcursoNavigation).WithMany(p => p.Progresocursos)
                .HasForeignKey(d => d.Idcurso)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("progresocurso_idcurso_fkey");

            entity.HasOne(d => d.IdusuarioNavigation).WithMany(p => p.Progresocursos)
                .HasForeignKey(d => d.Idusuario)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("progresocurso_idusuario_fkey");
        });

        modelBuilder.Entity<Progresotema>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("progresotema_pkey");

            entity.ToTable("progresotema");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Completado)
                .HasDefaultValue(false)
                .HasColumnName("completado");
            entity.Property(e => e.Fechacompletado)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fechacompletado");
            entity.Property(e => e.Fechainiciado)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fechainiciado");
            entity.Property(e => e.Idtema).HasColumnName("idtema");

            entity.HasOne(d => d.IdtemaNavigation).WithMany(p => p.Progresotemas)
                .HasForeignKey(d => d.Idtema)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("progresotema_idtema_fkey");
        });

        modelBuilder.Entity<Progresounidad>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("progresounidad_pkey");

            entity.ToTable("progresounidad");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Fechaactualizacion)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fechaactualizacion");
            entity.Property(e => e.Fechainicio)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fechainicio");
            entity.Property(e => e.Idunidad).HasColumnName("idunidad");
            entity.Property(e => e.Idusuario).HasColumnName("idusuario");
            entity.Property(e => e.Porcentaje)
                .HasPrecision(5, 2)
                .HasColumnName("porcentaje");

            entity.HasOne(d => d.IdunidadNavigation).WithMany(p => p.Progresounidads)
                .HasForeignKey(d => d.Idunidad)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("progresounidad_idunidad_fkey");

            entity.HasOne(d => d.IdusuarioNavigation).WithMany(p => p.Progresounidads)
                .HasForeignKey(d => d.Idusuario)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("progresounidad_idusuario_fkey");
        });

        modelBuilder.Entity<Reconocimiento>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("reconocimiento_pkey");

            entity.ToTable("reconocimiento");

            entity.HasIndex(e => e.Codigoverificacion, "reconocimiento_codigoverificacion_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Archivopdf).HasColumnName("archivopdf");
            entity.Property(e => e.Codigoverificacion)
                .HasMaxLength(100)
                .HasColumnName("codigoverificacion");
            entity.Property(e => e.Fechaemision)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fechaemision");
            entity.Property(e => e.Idcurso).HasColumnName("idcurso");
            entity.Property(e => e.Idusuario).HasColumnName("idusuario");

            entity.HasOne(d => d.IdcursoNavigation).WithMany(p => p.Reconocimientos)
                .HasForeignKey(d => d.Idcurso)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("reconocimiento_idcurso_fkey");

            entity.HasOne(d => d.IdusuarioNavigation).WithMany(p => p.Reconocimientos)
                .HasForeignKey(d => d.Idusuario)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("reconocimiento_idusuario_fkey");
        });

        modelBuilder.Entity<Recursounidad>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("recursounidad_pkey");

            entity.ToTable("recursounidad");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Archivo).HasColumnName("archivo");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(250)
                .HasColumnName("descripcion");
            entity.Property(e => e.Estado)
                .HasDefaultValue(true)
                .HasColumnName("estado");
            entity.Property(e => e.Idtiporecurso).HasColumnName("idtiporecurso");
            entity.Property(e => e.Idunidad).HasColumnName("idunidad");
            entity.Property(e => e.Metajsonb)
                .HasColumnType("jsonb")
                .HasColumnName("metajsonb");
            entity.Property(e => e.Nombre)
                .HasMaxLength(150)
                .HasColumnName("nombre");

            entity.HasOne(d => d.IdtiporecursoNavigation).WithMany(p => p.Recursounidads)
                .HasForeignKey(d => d.Idtiporecurso)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("recursounidad_idtiporecurso_fkey");

            entity.HasOne(d => d.IdunidadNavigation).WithMany(p => p.Recursounidads)
                .HasForeignKey(d => d.Idunidad)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("recursounidad_idunidad_fkey");
        });

        modelBuilder.Entity<Refreshtoken>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("refreshtokens_pkey");

            entity.ToTable("refreshtokens");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Fechacreacion)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fechacreacion");
            entity.Property(e => e.Fechaexpiracion)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fechaexpiracion");
            entity.Property(e => e.Idusuario).HasColumnName("idusuario");
            entity.Property(e => e.Revocado)
                .HasDefaultValue(false)
                .HasColumnName("revocado");
            entity.Property(e => e.Token).HasColumnName("token");

            entity.HasOne(d => d.IdusuarioNavigation).WithMany(p => p.Refreshtokens)
                .HasForeignKey(d => d.Idusuario)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("refreshtokens_idusuario_fkey");
        });

        modelBuilder.Entity<Registroactividad>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("registroactividad_pkey");

            entity.ToTable("registroactividad");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Accion)
                .HasMaxLength(200)
                .HasColumnName("accion");
            entity.Property(e => e.Detalle).HasColumnName("detalle");
            entity.Property(e => e.Fecha)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fecha");
            entity.Property(e => e.Idusuario).HasColumnName("idusuario");

            entity.HasOne(d => d.IdusuarioNavigation).WithMany(p => p.Registroactividads)
                .HasForeignKey(d => d.Idusuario)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("registroactividad_idusuario_fkey");
        });

        modelBuilder.Entity<Repuestausuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("repuestausuario_pkey");

            entity.ToTable("repuestausuario");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Calificacion)
                .HasPrecision(5, 2)
                .HasColumnName("calificacion");
            entity.Property(e => e.Fecharepuesta)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fecharepuesta");
            entity.Property(e => e.Idpreguntas).HasColumnName("idpreguntas");
            entity.Property(e => e.Idusuario).HasColumnName("idusuario");
            entity.Property(e => e.Seleccionado).HasColumnName("seleccionado");

            entity.HasOne(d => d.IdpreguntasNavigation).WithMany(p => p.Repuestausuarios)
                .HasForeignKey(d => d.Idpreguntas)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("repuestausuario_idpreguntas_fkey");

            entity.HasOne(d => d.IdusuarioNavigation).WithMany(p => p.Repuestausuarios)
                .HasForeignKey(d => d.Idusuario)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("repuestausuario_idusuario_fkey");
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("rol_pkey");

            entity.ToTable("rol");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Descripción)
                .HasMaxLength(250)
                .HasColumnName("descripción");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.Nombre)
                .HasMaxLength(70)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Seguidore>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("seguidores_pkey");

            entity.ToTable("seguidores");

            entity.HasIndex(e => new { e.Idusuario, e.Seguidorusuarioid }, "seguidores_idusuario_seguidorusuarioid_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Fecha)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fecha");
            entity.Property(e => e.Idusuario).HasColumnName("idusuario");
            entity.Property(e => e.Seguidorusuarioid).HasColumnName("seguidorusuarioid");

            entity.HasOne(d => d.IdusuarioNavigation).WithMany(p => p.SeguidoreIdusuarioNavigations)
                .HasForeignKey(d => d.Idusuario)
                .HasConstraintName("seguidores_idusuario_fkey");

            entity.HasOne(d => d.Seguidorusuario).WithMany(p => p.SeguidoreSeguidorusuarios)
                .HasForeignKey(d => d.Seguidorusuarioid)
                .HasConstraintName("seguidores_seguidorusuarioid_fkey");
        });

        modelBuilder.Entity<Sugerenciacurso>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("sugerenciacurso_pkey");

            entity.ToTable("sugerenciacurso");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Categoriasugerida)
                .HasMaxLength(150)
                .HasColumnName("categoriasugerida");
            entity.Property(e => e.Descripcion).HasColumnName("descripcion");
            entity.Property(e => e.Estado)
                .HasMaxLength(50)
                .HasDefaultValueSql("'Pendiente'::character varying")
                .HasColumnName("estado");
            entity.Property(e => e.Fechasugerencia)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fechasugerencia");
            entity.Property(e => e.Idusuario).HasColumnName("idusuario");
            entity.Property(e => e.Titulo)
                .HasMaxLength(200)
                .HasColumnName("titulo");
            entity.Property(e => e.Votos)
                .HasDefaultValue(0)
                .HasColumnName("votos");

            entity.HasOne(d => d.IdusuarioNavigation).WithMany(p => p.Sugerenciacursos)
                .HasForeignKey(d => d.Idusuario)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("sugerenciacurso_idusuario_fkey");
        });

        modelBuilder.Entity<Suscripcione>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("suscripciones_pkey");

            entity.ToTable("suscripciones");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Estado)
                .HasDefaultValue(true)
                .HasColumnName("estado");
            entity.Property(e => e.Fechafin)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fechafin");
            entity.Property(e => e.Fechainicio)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fechainicio");
            entity.Property(e => e.Idplan).HasColumnName("idplan");
            entity.Property(e => e.Idusuario).HasColumnName("idusuario");

            entity.HasOne(d => d.IdplanNavigation).WithMany(p => p.Suscripciones)
                .HasForeignKey(d => d.Idplan)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("suscripciones_idplan_fkey");

            entity.HasOne(d => d.IdusuarioNavigation).WithMany(p => p.Suscripciones)
                .HasForeignKey(d => d.Idusuario)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("suscripciones_idusuario_fkey");
        });

        modelBuilder.Entity<Tema>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("temas_pkey");

            entity.ToTable("temas");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(250)
                .HasColumnName("descripcion");
            entity.Property(e => e.Idunidad).HasColumnName("idunidad");
            entity.Property(e => e.Orden).HasColumnName("orden");
            entity.Property(e => e.Titulo)
                .HasMaxLength(150)
                .HasColumnName("titulo");

            entity.HasOne(d => d.IdunidadNavigation).WithMany(p => p.Temas)
                .HasForeignKey(d => d.Idunidad)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("temas_idunidad_fkey");
        });

        modelBuilder.Entity<Tipoactividad>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("tipoactividad_pkey");

            entity.ToTable("tipoactividad");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(300)
                .HasColumnName("descripcion");
            entity.Property(e => e.Estado)
                .HasDefaultValue(true)
                .HasColumnName("estado");
            entity.Property(e => e.Tipo)
                .HasMaxLength(200)
                .HasColumnName("tipo");
        });

        modelBuilder.Entity<Tipoenlaceprof>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("tipoenlaceprof_pkey");

            entity.ToTable("tipoenlaceprof");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nombre)
                .HasMaxLength(150)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Tipoevaluacion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("tipoevaluacion_pkey");

            entity.ToTable("tipoevaluacion");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Descripción)
                .HasMaxLength(250)
                .HasColumnName("descripción");
            entity.Property(e => e.Estado)
                .HasDefaultValue(true)
                .HasColumnName("estado");
            entity.Property(e => e.Tipo)
                .HasMaxLength(150)
                .HasColumnName("tipo");
        });

        modelBuilder.Entity<Tipopreguntum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("tipopregunta_pkey");

            entity.ToTable("tipopregunta");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Descripción)
                .HasMaxLength(250)
                .HasColumnName("descripción");
            entity.Property(e => e.Estado)
                .HasDefaultValue(true)
                .HasColumnName("estado");
            entity.Property(e => e.Tipo)
                .HasMaxLength(150)
                .HasColumnName("tipo");
        });

        modelBuilder.Entity<Tiporecurso>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("tiporecurso_pkey");

            entity.ToTable("tiporecurso");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(250)
                .HasColumnName("descripcion");
            entity.Property(e => e.Estado)
                .HasDefaultValue(true)
                .HasColumnName("estado");
            entity.Property(e => e.Tipo)
                .HasMaxLength(150)
                .HasColumnName("tipo");
        });

        modelBuilder.Entity<Tituloprofesor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("tituloprofesor_pkey");

            entity.ToTable("tituloprofesor");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Archivocomprobante).HasColumnName("archivocomprobante");
            entity.Property(e => e.Fechafin)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fechafin");
            entity.Property(e => e.Fechainicio)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fechainicio");
            entity.Property(e => e.Idprofesor).HasColumnName("idprofesor");
            entity.Property(e => e.Institucion)
                .HasMaxLength(120)
                .HasColumnName("institucion");
            entity.Property(e => e.Nombtitulo)
                .HasMaxLength(120)
                .HasColumnName("nombtitulo");

            entity.HasOne(d => d.IdprofesorNavigation).WithMany(p => p.Tituloprofesors)
                .HasForeignKey(d => d.Idprofesor)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("tituloprofesor_idprofesor_fkey");
        });

        modelBuilder.Entity<Tutoriale>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("tutoriales_pkey");

            entity.ToTable("tutoriales");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Estado)
                .HasDefaultValue(true)
                .HasColumnName("estado");
            entity.Property(e => e.Fechacreacion)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fechacreacion");
            entity.Property(e => e.Fechamodificacion)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fechamodificacion");
            entity.Property(e => e.Idusuario).HasColumnName("idusuario");
            entity.Property(e => e.Titulo)
                .HasMaxLength(150)
                .HasColumnName("titulo");

            entity.HasOne(d => d.IdusuarioNavigation).WithMany(p => p.Tutoriales)
                .HasForeignKey(d => d.Idusuario)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("tutoriales_idusuario_fkey");
        });

        modelBuilder.Entity<Unidad>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("unidad_pkey");

            entity.ToTable("unidad");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(250)
                .HasColumnName("descripcion");
            entity.Property(e => e.Idmodulo).HasColumnName("idmodulo");
            entity.Property(e => e.Orden).HasColumnName("orden");
            entity.Property(e => e.Titulo)
                .HasMaxLength(150)
                .HasColumnName("titulo");

            entity.HasOne(d => d.IdmoduloNavigation).WithMany(p => p.Unidads)
                .HasForeignKey(d => d.Idmodulo)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("unidad_idmodulo_fkey");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("usuario_pkey");

            entity.ToTable("usuario");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Contrasenia)
                .HasMaxLength(75)
                .HasColumnName("contrasenia");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(250)
                .HasColumnName("descripcion");
            entity.Property(e => e.Fechamodificacion)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fechamodificacion");
            entity.Property(e => e.Fecharegistro)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fecharegistro");
            entity.Property(e => e.Ididioma).HasColumnName("ididioma");
            entity.Property(e => e.Idrol).HasColumnName("idrol");
            entity.Property(e => e.Imgusuario).HasColumnName("imgusuario");
            entity.Property(e => e.Nombreusuario)
                .HasMaxLength(85)
                .HasColumnName("nombreusuario");
            entity.Property(e => e.Primerapellido)
                .HasMaxLength(100)
                .HasColumnName("primerapellido");
            entity.Property(e => e.Primernombre)
                .HasMaxLength(100)
                .HasColumnName("primernombre");
            entity.Property(e => e.Segundoapellido)
                .HasMaxLength(100)
                .HasColumnName("segundoapellido");
            entity.Property(e => e.Segundonombre)
                .HasMaxLength(100)
                .HasColumnName("segundonombre");
            entity.Property(e => e.Telefono)
                .HasMaxLength(25)
                .HasColumnName("telefono");

            entity.HasOne(d => d.IdidiomaNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.Ididioma)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_usuario_ididioma");

            entity.HasOne(d => d.IdrolNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.Idrol)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_usuario_idrol");
        });

        modelBuilder.Entity<Usuario2fa>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("usuario2fa_pkey");

            entity.ToTable("usuario2fa");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Activo)
                .HasDefaultValue(false)
                .HasColumnName("activo");
            entity.Property(e => e.Fechaactivacion)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fechaactivacion");
            entity.Property(e => e.Secreto).HasColumnName("secreto");
            entity.Property(e => e.Tipo)
                .HasMaxLength(50)
                .HasColumnName("tipo");
            entity.Property(e => e.Ultimocodigo)
                .HasMaxLength(10)
                .HasColumnName("ultimocodigo");

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.Usuario2fa)
                .HasForeignKey<Usuario2fa>(d => d.Id)
                .HasConstraintName("usuario2fa_id_fkey");
        });

        modelBuilder.Entity<Usuariooauth>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("usuariooauth_pkey");

            entity.ToTable("usuariooauth");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Accesstoken).HasColumnName("accesstoken");
            entity.Property(e => e.Fechaexpiracion)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fechaexpiracion");
            entity.Property(e => e.Identidadexterna)
                .HasMaxLength(200)
                .HasColumnName("identidadexterna");
            entity.Property(e => e.Idusuario).HasColumnName("idusuario");
            entity.Property(e => e.Proveedor)
                .HasMaxLength(50)
                .HasColumnName("proveedor");
            entity.Property(e => e.Refreshtoken).HasColumnName("refreshtoken");

            entity.HasOne(d => d.IdusuarioNavigation).WithMany(p => p.Usuariooauths)
                .HasForeignKey(d => d.Idusuario)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("usuariooauth_idusuario_fkey");
        });

        modelBuilder.Entity<Videocurso>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("videocurso_pkey");

            entity.ToTable("videocurso");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Descripcion).HasColumnName("descripcion");
            entity.Property(e => e.Estado)
                .HasDefaultValue(true)
                .HasColumnName("estado");
            entity.Property(e => e.Fechamodificación)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fechamodificación");
            entity.Property(e => e.Fechapublicacion)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fechapublicacion");
            entity.Property(e => e.Idcurso).HasColumnName("idcurso");
            entity.Property(e => e.Publicadopor).HasColumnName("publicadopor");
            entity.Property(e => e.Rutaarchivo).HasColumnName("rutaarchivo");
            entity.Property(e => e.Titulo)
                .HasMaxLength(150)
                .HasColumnName("titulo");

            entity.HasOne(d => d.IdcursoNavigation).WithMany(p => p.Videocursos)
                .HasForeignKey(d => d.Idcurso)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("videocurso_idcurso_fkey");

            entity.HasOne(d => d.PublicadoporNavigation).WithMany(p => p.Videocursos)
                .HasForeignKey(d => d.Publicadopor)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("videocurso_publicadopor_fkey");
        });

        modelBuilder.Entity<Videotutoriale>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("videotutoriales_pkey");

            entity.ToTable("videotutoriales");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Descripcion).HasColumnName("descripcion");
            entity.Property(e => e.Fechamodificacion)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fechamodificacion");
            entity.Property(e => e.Fechapublicacion)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fechapublicacion");
            entity.Property(e => e.Idtutorial).HasColumnName("idtutorial");
            entity.Property(e => e.Idusuario).HasColumnName("idusuario");
            entity.Property(e => e.Titulo)
                .HasMaxLength(300)
                .HasColumnName("titulo");
            entity.Property(e => e.Video).HasColumnName("video");

            entity.HasOne(d => d.IdtutorialNavigation).WithMany(p => p.Videotutoriales)
                .HasForeignKey(d => d.Idtutorial)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("videotutoriales_idtutorial_fkey");

            entity.HasOne(d => d.IdusuarioNavigation).WithMany(p => p.Videotutoriales)
                .HasForeignKey(d => d.Idusuario)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("videotutoriales_idusuario_fkey");
        });

        modelBuilder.Entity<Votosugerencium>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("votosugerencia_pkey");

            entity.ToTable("votosugerencia");

            entity.HasIndex(e => new { e.Idusuario, e.Idsugerencia }, "votosugerencia_idusuario_idsugerencia_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Fechavoto)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fechavoto");
            entity.Property(e => e.Idsugerencia).HasColumnName("idsugerencia");
            entity.Property(e => e.Idusuario).HasColumnName("idusuario");

            entity.HasOne(d => d.IdsugerenciaNavigation).WithMany(p => p.Votosugerencia)
                .HasForeignKey(d => d.Idsugerencia)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("votosugerencia_idsugerencia_fkey");

            entity.HasOne(d => d.IdusuarioNavigation).WithMany(p => p.Votosugerencia)
                .HasForeignKey(d => d.Idusuario)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("votosugerencia_idusuario_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
