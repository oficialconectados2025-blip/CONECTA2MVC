using CONECTA2MVC.Entidad.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CONECTA2MVC.Negocio.Interfaces
{
    public interface IUsuarioService
    {

        Task<List<Usuario>> Lista();
        Task<Usuario> Crear(Usuario entidad);
        Task<Usuario> Editar(Usuario entidad);
        Task<Usuario> Eliminar(Usuario entidad);
        Task<IQueryable<Usuario>> ObtenerTodo();

        Task<Usuario> ObtenerPorNombre(int id);

    }
}
