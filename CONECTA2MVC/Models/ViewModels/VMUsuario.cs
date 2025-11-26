using CONECTA2MVC.Entidad.Models;
using System.ComponentModel.DataAnnotations;

namespace CONECTA2MVC.Models.ViewModels
{
    public class VMUsuario
    {
        public int Id { get; set; }
        [Required, StringLength(50)]
        public string Primernombre { get; set; } = string.Empty;
        [Required, StringLength(50)]
        public string Segundonombre { get; set; } = string.Empty ;
        [Required, StringLength(50)]
        public string Primerapellido { get; set; } = string.Empty;
        [Required, StringLength(50)]
        public string Segundoapellido { get; set; } = string.Empty;
        [Required, StringLength(50)]
        public string Nombreusuario { get; set; } = string.Empty;
        [Required, StringLength(100)]
        public string Contrasenia { get; set; } = string.Empty;
        [Phone]
        public string? Telefono { get; set; }       
        public string? Descripcion { get; set; }     
        public string? Imgusuario { get; set; }
        [Required]
        public int Idrol { get; set; }
        [Required]
        public int Ididioma { get; set; }

        public virtual Idioma? IdidiomaNavigation { get; set; }
        public virtual Rol? IdrolNavigation { get; set; }
    }
}
